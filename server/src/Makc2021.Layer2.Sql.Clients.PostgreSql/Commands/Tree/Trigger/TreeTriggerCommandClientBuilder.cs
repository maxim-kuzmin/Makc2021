﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Linq;
using System.Text;
using Makc2021.Layer2.Sql.Clients.PostgreSql.Commands.Tree.Calculate;
using Makc2021.Layer2.Sql.Commands.Tree.Trigger;
using Makc2021.Layer2.Sql.Commands.Trigger;

namespace Makc2021.Layer2.Sql.Clients.PostgreSql.Commands.Tree.Trigger
{
    /// <summary>
    /// Построитель команды на срабатывание триггера дерева у клиента.
    /// </summary>
    public class TreeTriggerCommandClientBuilder : TreeTriggerCommandBuilder
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
            string aliasForIds = $"\"{Prefix}ids\"";
            string aliasForAncestors = $"\"{Prefix}a\"";
            string aliasForTree = $"\"{Prefix}t\"";

            string cteForAll = $"\"{Prefix}cte_All\"";
            string cteForAncestors = $"\"{Prefix}cte_Ancestors\"";

            string linkTableFieldNameForId = $"\"{LinkTableFieldNameForId}\"";
            string linkTableFieldNameForParentId = $"\"{LinkTableFieldNameForParentId}\"";

            string linkTableName = $"\"{LinkTableSchema}\".\"{LinkTableNameWithoutSchema}\"";

            string tableNameForIds = $"_{Prefix}Ids";
            string tableNameForIdsAncestor = $"_{Prefix}IdsAncestor";
            string tableNameForIdsBroken = $"_{Prefix}IdsBroken";
            string tableNameForIdsCalculated = $"_{Prefix}IdsCalculated";
            string tableNameForIdsDescendant = $"_{Prefix}IdsDescendant";
            string tableNameForIdsLinked = $"_{Prefix}IdsLinked";

            string treeTableFieldNameForId = $"\"{TreeTableFieldNameForId}\"";
            string treeTableFieldNameForParentId = $"\"{TreeTableFieldNameForParentId}\"";

            string treeTableName = $"\"{TreeTableSchema}\".\"{TreeTableNameWithoutSchema}\"";

            string val = "\"val\"";

            string sqlForIdsSelectQuery = string.Empty;

            System.Collections.Generic.List<System.Data.Common.DbParameter> parIds = Parameters.Ids;

            if (parIds.Any() || !string.IsNullOrWhiteSpace(SqlForIdsSelectQuery))
            {
                sqlForIdsSelectQuery = parIds.Any()
                    ?
                    "values (" + string.Join("), (", parIds.Select(x => x.ParameterName)) + ")"
                    :
                    SqlForIdsSelectQuery;
            }
            else
            {
                sqlForIdsSelectQuery = $"select {treeTableFieldNameForId} from {treeTableName}";
            }

            string sqlForCalculate = CreateSqlForCalculate($"select distinct {val} from {tableNameForIdsCalculated}");

            string variableNameForAction = $"_{Prefix}Action";

            string valueForActionDelete = "'D'";
            string valueForActionInsert = "'I'";
            string valueForActionUpdate = "'U'";

            string variableValueForAction = "''";

            switch (Action)
            {
                case TriggerCommandAction.Delete:
                    variableValueForAction = valueForActionDelete;
                    break;
                case TriggerCommandAction.Insert:
                    variableValueForAction = valueForActionInsert;
                    break;
                case TriggerCommandAction.Update:
                    variableValueForAction = valueForActionUpdate;
                    break;
            }

            StringBuilder result = new($@"
do $$
declare
	{variableNameForAction} char := {variableValueForAction};
begin
	create temp table {tableNameForIds} ({val} bigint);
	create temp table {tableNameForIdsAncestor} ({val} bigint);
	create temp table {tableNameForIdsBroken} ({val} bigint);
	create temp table {tableNameForIdsCalculated} ({val} bigint);
	create temp table {tableNameForIdsDescendant} ({val} bigint);
	create temp table {tableNameForIdsLinked} ({val} bigint);		

	insert into {tableNameForIds}
	(
		{val}
	)
	{sqlForIdsSelectQuery}
	;

	-- Добавляем узлы к разрушенным узлам.
	insert into {tableNameForIdsBroken}
	(
		{val}
	)
	select
		{val}
	from
		{tableNameForIds}
	;

	-- Удаление или обновление.
	if ({variableNameForAction} <> {valueForActionInsert}) then	
		-- Запоминаем идентификаторы предков удалённых или обновлённых узлов.
		insert into {tableNameForIdsAncestor}
		(
			{val}
		)
		select distinct
			{linkTableFieldNameForParentId}
		from
			{linkTableName}
		where
			{linkTableFieldNameForParentId} > 0
			and 
			{linkTableFieldNameForId} <> {linkTableFieldNameForParentId}
			and
			{linkTableFieldNameForId} in (select {val} from {tableNameForIds})
		;
	end if;

	-- Обновление.
	if ({variableNameForAction} = {valueForActionUpdate}) then
		-- Запоминаем идентификаторы потомков обновлённых узлов.
		insert into {tableNameForIdsDescendant}
		(
			{val}
		)
		select distinct
			{linkTableFieldNameForId}
		from
			{linkTableName}
		where
			{linkTableFieldNameForId} <> {linkTableFieldNameForParentId}
			and
			{linkTableFieldNameForParentId} in (select {val} from {tableNameForIds})
		;

		-- Добавляем потомков обновлённых узлов к разрушенным узлам.
		insert into {tableNameForIdsBroken}
		(
			{val}
		)
		select
			{val}
		from
			{tableNameForIdsDescendant}
		;

		-- Добавляем потомков обновлённых узлов к связываемым узлам.
		insert into {tableNameForIdsLinked}
		(
			{val}
		)
		select
			{val}
		from
			{tableNameForIdsDescendant}
		;
	end if;

	-- Вставка или обновление.
	if ({variableNameForAction} <> {valueForActionDelete}) then
		-- Добавляем вставленные или обновлённые узлы к связываемым узлам.
		insert into {tableNameForIdsLinked}
		(
			{val}
		)
		select
			{val}
		from
			{tableNameForIds}
		;

		-- Добавляем родителей вставленных или обновлённых узлов к вычисляемым узлам.
		insert into {tableNameForIdsCalculated}
		(
			{val}
		)
		select distinct
			{treeTableFieldNameForParentId}
		from
			{treeTableName}
		where
			{treeTableFieldNameForParentId} is not null
			and
			{treeTableFieldNameForId} in (select {val} from {tableNameForIds})
		;

		-- Запоминаем идентификаторы предков родителей вставленных или обновлённых узлов.
		insert into {tableNameForIdsAncestor}
		(
			{val}
		)
		select distinct
			{linkTableFieldNameForParentId}
		from
			{linkTableName}
		where
			{linkTableFieldNameForParentId} > 0
			and
			{linkTableFieldNameForId} <> {linkTableFieldNameForParentId}
			and
			{linkTableFieldNameForId} in (select {val} from {tableNameForIdsCalculated})
		;

		-- Добавляем вставленные или обновлённые узлы к вычисляемым узлам.
		insert into {tableNameForIdsCalculated}
		(
			{val}
		)
		select
			{val}
		from
			{tableNameForIds}
		;
	end if;

	-- Добавляем предков к вычисляемым узлам.
	insert into {tableNameForIdsCalculated}
	(
		{val}
	)
	select
		{val}
	from
		{tableNameForIdsAncestor}
	;

	-- Обновление.
	if ({variableNameForAction} = {valueForActionUpdate}) then
		-- Добавляем потомков обновлённых узлов к вычисляемым узлам.
		insert into {tableNameForIdsCalculated}
		(
			{val}
		)
		select
			{val}
		from
			{tableNameForIdsDescendant}
		;
	end if;

	-- Удаляем связи разрушенных узлов.
	delete from	{linkTableName}
	where
		{linkTableFieldNameForId} in (select {val} from {tableNameForIdsBroken})
	;		

	-- Добавляем связи разрушенных узлов.
	with recursive {cteForAncestors} as
	(
		select
			{aliasForTree}.{treeTableFieldNameForId} {treeTableFieldNameForId},
			COALESCE({aliasForTree}.{treeTableFieldNameForParentId}, 0) {treeTableFieldNameForParentId}
		from
			{treeTableName} {aliasForTree}
			inner join {tableNameForIdsLinked} {aliasForIds}
				on {aliasForTree}.{treeTableFieldNameForId} = {aliasForIds}.{val}
		union all
		select
			{aliasForAncestors}.{treeTableFieldNameForId} {treeTableFieldNameForId},
			COALESCE({aliasForTree}.{treeTableFieldNameForParentId}, 0) {treeTableFieldNameForParentId}
		from 
			{treeTableName} {aliasForTree}
			inner join {cteForAncestors} {aliasForAncestors}
				on {aliasForTree}.{treeTableFieldNameForId} = {aliasForAncestors}.{treeTableFieldNameForParentId}
	),
	{cteForAll} as 
	(
		select
			{aliasForTree}.{treeTableFieldNameForId} {treeTableFieldNameForId},
			{aliasForTree}.{treeTableFieldNameForId} {treeTableFieldNameForParentId}
		from
			{treeTableName} {aliasForTree}
			inner join {tableNameForIdsLinked} {aliasForIds}
				on {aliasForTree}.{treeTableFieldNameForId} = {aliasForIds}.{val}
		union all
		select
			{treeTableFieldNameForId}, 
			{treeTableFieldNameForParentId}
		from 
			{cteForAncestors}
	)
	insert into {linkTableName}
	(
		{linkTableFieldNameForId},
		{linkTableFieldNameForParentId}
	)
	select
		{treeTableFieldNameForId}, 
		{treeTableFieldNameForParentId}
	from
		{cteForAll}
	;
end $$;

{sqlForCalculate}
");

            return result.ToString();
        }

        #endregion Public methods

        #region Private methods

        private string CreateSqlForCalculate(string sqlForIdsSelectQuery)
        {
            return new TreeCalculateCommandClientBuilder
            {
                LinkTableFieldNameForId = LinkTableFieldNameForId,
                LinkTableFieldNameForParentId = LinkTableFieldNameForParentId,
                LinkTableNameWithoutSchema = LinkTableNameWithoutSchema,
                LinkTableSchema = LinkTableSchema,
                SqlForIdsSelectQuery = sqlForIdsSelectQuery,
                TreeTableFieldNameForId = TreeTableFieldNameForId,
                TreeTableFieldNameForParentId = TreeTableFieldNameForParentId,
                TreeTableFieldNameForTreeChildCount = TreeTableFieldNameForTreeChildCount,
                TreeTableFieldNameForTreeDescendantCount = TreeTableFieldNameForTreeDescendantCount,
                TreeTableFieldNameForTreeLevel = TreeTableFieldNameForTreeLevel,
                TreeTableFieldNameForTreePath = TreeTableFieldNameForTreePath,
                TreeTableFieldNameForTreePosition = TreeTableFieldNameForTreePosition,
                TreeTableFieldNameForTreeSort = TreeTableFieldNameForTreeSort,
                TreeTableNameWithoutSchema = TreeTableNameWithoutSchema,
                TreeTableSchema = TreeTableSchema
            }.GetResultSql();
        }

        #endregion Private methods
    }
}
