﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Linq;
using System.Text;
using Makc2021.Layer2.Sql.Commands.Tree.Calculate;

namespace Makc2021.Layer2.Sql.Clients.PostgreSql.Commands.Tree.Calculate
{
    /// <summary>
    /// Построитель команды на вычисление дерева у клиента.
    /// </summary>
    public class TreeCalculateCommandClientBuilder : TreeCalculateCommandBuilder
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
            string aliasForLink = $"\"{Prefix}k\"";
            string aliasForLink1 = $"\"{Prefix}k1\"";
            string aliasForLink2 = $"\"{Prefix}k2\"";
            string aliasForResult = $"\"{Prefix}r\"";
            string aliasForTree = $"\"{Prefix}t\"";

            string cte = "\"cte\"";

            string linkTableFieldNameForId = $"\"{LinkTableFieldNameForId}\"";
            string linkTableFieldNameForParentId = $"\"{LinkTableFieldNameForParentId}\"";

            string linkTableName = $"\"{LinkTableSchema}\".\"{LinkTableNameWithoutSchema}\"";

            string treeTableFieldNameForId = $"\"{TreeTableFieldNameForId}\"";
            string treeTableFieldNameForParentId = $"\"{TreeTableFieldNameForParentId}\"";
            string treeTableFieldNameForTreeChildCount = $"\"{TreeTableFieldNameForTreeChildCount}\"";
            string treeTableFieldNameForTreeDescendantCount = $"\"{TreeTableFieldNameForTreeDescendantCount}\"";
            string treeTableFieldNameForTreeLevel = $"\"{TreeTableFieldNameForTreeLevel}\"";
            string treeTableFieldNameForTreePath = $"\"{TreeTableFieldNameForTreePath}\"";
            string treeTableFieldNameForTreePosition = $"\"{TreeTableFieldNameForTreePosition}\"";
            string treeTableFieldNameForTreeSort = $"\"{TreeTableFieldNameForTreeSort}\"";

            string treeTableName = $"\"{TreeTableSchema}\".\"{TreeTableNameWithoutSchema}\"";

            string val = "\"val\"";

            StringBuilder result = new($@"
do $$
begin
	loop
		with {cte} as
		(
			select
				{treeTableFieldNameForId},
				{treeTableFieldNameForParentId},
				{treeTableFieldNameForTreePosition}
			from
				{treeTableName}
			where
				{treeTableFieldNameForTreePosition} = 0
			limit 1
		)
		update {treeTableName} set
			{treeTableFieldNameForTreePosition} = 
			(
				select
					MAX({aliasForTree}.{treeTableFieldNameForTreePosition}) + 10
				from
					{treeTableName} {aliasForTree}
				where
					COALESCE({aliasForTree}.{treeTableFieldNameForParentId}, 0) = COALESCE({cte}.{treeTableFieldNameForParentId}, 0)
			)
		from
			{cte}
		where
			{treeTableName}.{treeTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
		;

		if not FOUND then
			exit;
		end if;
	end loop;

	with {cte} as
	(
		select
			{treeTableFieldNameForId},
			{treeTableFieldNameForTreeChildCount},
			{treeTableFieldNameForTreeDescendantCount},
			{treeTableFieldNameForTreeLevel},
			{treeTableFieldNameForTreePath},
			{treeTableFieldNameForTreeSort}
		from
			{treeTableName}
	)
	update {treeTableName} set
		{treeTableFieldNameForTreeChildCount} = 
		(
			select
				COUNT(*)
			from
				{treeTableName} {aliasForTree}
			where
				{aliasForTree}.{treeTableFieldNameForParentId} = {cte}.{treeTableFieldNameForId}
		),
		{treeTableFieldNameForTreeDescendantCount} = 
		(
			select
				COUNT(*)
			from
				{linkTableName} {aliasForLink}
			where
				{aliasForLink}.{linkTableFieldNameForParentId} = {cte}.{treeTableFieldNameForId}
				and
				{aliasForLink}.{linkTableFieldNameForParentId} <> {aliasForLink}.{linkTableFieldNameForId}
		),
		{treeTableFieldNameForTreeLevel} = 
		(
			select
				COUNT(*) - 1
			from
				{linkTableName} {aliasForLink}
			where
				{aliasForLink}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
		),
		{treeTableFieldNameForTreePath} =
		(
			select
				COALESCE({aliasForResult}.{val}, '')
			from
			(
				select
					{aliasForLink1}.{linkTableFieldNameForId},
					(
						select
							STRING_AGG({aliasForLink2}.{linkTableFieldNameForParentId}::text, ',')
						from
							{linkTableName} {aliasForLink2}
						where
							{aliasForLink1}.{linkTableFieldNameForId} = {aliasForLink2}.{linkTableFieldNameForId}
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} > 0
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} <> {aliasForLink2}.{linkTableFieldNameForId}
					) {val}
				from
					{linkTableName} {aliasForLink1}
				group by
					{aliasForLink1}.{linkTableFieldNameForId}
			) {aliasForResult}
			where
				{aliasForResult}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
		),
		{treeTableFieldNameForTreeSort} =
		(
			select
				COALESCE({aliasForResult}.{val}, '')
			from
			(
				select
					{aliasForLink1}.{linkTableFieldNameForId},
					(
						select
							STRING_AGG(RIGHT('0000000000' || {aliasForTree}.{treeTableFieldNameForTreePosition}::text || '.' || {aliasForLink2}.{linkTableFieldNameForParentId}::text, 10), ',')
						from
							{linkTableName} {aliasForLink2}
							inner join {treeTableName} {aliasForTree}
								on {aliasForLink2}.{linkTableFieldNameForParentId} = {aliasForTree}.{treeTableFieldNameForId}
						where
							{aliasForLink1}.{linkTableFieldNameForId} = {aliasForLink2}.{linkTableFieldNameForId}
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} > 0
					) {val}
				from
					{linkTableName} {aliasForLink1}
				group by
					{aliasForLink1}.{linkTableFieldNameForId}
			) {aliasForResult}
			where
				{aliasForResult}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
		)
	from
		{cte}
	where
		{treeTableName}.{treeTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
");
            System.Collections.Generic.List<System.Data.Common.DbParameter> parIds = Parameters.Ids;

            if (parIds.Any() || !string.IsNullOrWhiteSpace(SqlForIdsSelectQuery))
            {
                string sqlForIdsSelectQuery = parIds.Any()
                    ?
                    string.Join(", ", parIds.Select(x => x.ParameterName))
                    :
                    SqlForIdsSelectQuery;

                result.Append($@"
		and
		{cte}.{treeTableFieldNameForId} in
		(
			{sqlForIdsSelectQuery}
		)
	;
");
                result.Append($@"
end $$;
");
            }

            return result.ToString();
        }

        #endregion Public methods
    }
}
