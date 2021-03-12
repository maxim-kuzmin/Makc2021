// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer2.Clients.PostgreSql.Queries.Tree.Calculate;
using Makc2021.Layer2.Queries.Tree.Trigger;
using Makc2021.Layer2.Trigger;
using System.Linq;
using System.Text;

namespace Makc2021.Layer2.Clients.PostgreSql.Queries.Tree.Trigger
{
    /// <summary>
    /// База данных "PostgreSQL". Запрос триггера дерева. Построитель.
    /// </summary>
    public class ClientTreeTriggerQueryBuilder : TreeTriggerQueryBuilder
	{
		#region Public methods

		/// <inheritdoc/>
		public sealed override string GetResultSql()
		{
			var aliasForIds = $"\"{Prefix}ids\"";
			var aliasForAncestors = $"\"{Prefix}a\"";
			var aliasForTree = $"\"{Prefix}t\"";

			var cteForAll = $"\"{Prefix}cte_All\"";
			var cteForAncestors = $"\"{Prefix}cte_Ancestors\"";

			var linkTableFieldNameForId = $"\"{LinkTableFieldNameForId}\"";
			var linkTableFieldNameForParentId = $"\"{LinkTableFieldNameForParentId}\"";

			var linkTableName = $"\"{LinkTableSchema}\".\"{LinkTableNameWithoutSchema}\"";

			var tableNameForIds = $"_{Prefix}Ids";
			var tableNameForIdsAncestor = $"_{Prefix}IdsAncestor";
			var tableNameForIdsBroken = $"_{Prefix}IdsBroken";
			var tableNameForIdsCalculated = $"_{Prefix}IdsCalculated";
			var tableNameForIdsDescendant = $"_{Prefix}IdsDescendant";
			var tableNameForIdsLinked = $"_{Prefix}IdsLinked";

			var treeTableFieldNameForId = $"\"{TreeTableFieldNameForId}\"";
			var treeTableFieldNameForParentId = $"\"{TreeTableFieldNameForParentId}\"";

			var treeTableName = $"\"{TreeTableSchema}\".\"{TreeTableNameWithoutSchema}\"";

			var val = "\"val\"";

			var sqlForIdsSelectQuery = string.Empty;

			var parIds = Parameters.Ids;

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

			var sqlForCalculate = CreateSqlForCalculate($"select distinct {val} from {tableNameForIdsCalculated}");

			var variableNameForAction = $"_{Prefix}Action";

			var valueForActionDelete = "'D'";
			var valueForActionInsert = "'I'";
			var valueForActionUpdate = "'U'";

			var variableValueForAction = "''";

			switch (Action)
			{
				case TriggerAction.Delete:
					variableValueForAction = valueForActionDelete;
					break;
				case TriggerAction.Insert:
					variableValueForAction = valueForActionInsert;
					break;
				case TriggerAction.Update:
					variableValueForAction = valueForActionUpdate;
					break;
			}

			var result = new StringBuilder($@"
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
			return new ClientTreeCalculateQueryBuilder
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
