﻿//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Queries.Tree.Calculate;
using System.Linq;
using System.Text;

namespace Makc2021.Layer2.DBs.SqlServer.Queries.Tree.Calculate
{
	/// <summary>
	/// База данных "Microsoft SQL Server". Запрос вычисления дерева. Построитель.
	/// </summary>
	public class SqlServerTreeCalculateQueryBuilder : TreeCalculateQueryBuilder
	{
		#region Public methods

		/// <inheritdoc/>
		public sealed override string GetResultSql()
		{
			var aliasForLink = $"[{Prefix}k]";
			var aliasForLink1 = $"[{Prefix}k1]";
			var aliasForLink2 = $"[{Prefix}k2]";
			var aliasForResult = $"[{Prefix}r]";
			var aliasForTree = $"[{Prefix}t]";

			var cte = "[cte]";

			var linkTableFieldNameForId = $"[{LinkTableFieldNameForId}]";
			var linkTableFieldNameForParentId = $"[{LinkTableFieldNameForParentId}]";

			var linkTableName = $"[{LinkTableSchema}].[{LinkTableNameWithoutSchema}]";

			var treeTableFieldNameForId = $"[{TreeTableFieldNameForId}]";
			var treeTableFieldNameForParentId = $"[{TreeTableFieldNameForParentId}]";
			var treeTableFieldNameForTreeChildCount = $"[{TreeTableFieldNameForTreeChildCount}]";
			var treeTableFieldNameForTreeDescendantCount = $"[{TreeTableFieldNameForTreeDescendantCount}]";
			var treeTableFieldNameForTreeLevel = $"[{TreeTableFieldNameForTreeLevel}]";
			var treeTableFieldNameForTreePath = $"[{TreeTableFieldNameForTreePath}]";
			var treeTableFieldNameForTreePosition = $"[{TreeTableFieldNameForTreePosition}]";
			var treeTableFieldNameForTreeSort = $"[{TreeTableFieldNameForTreeSort}]";

			var treeTableName = $"[{TreeTableSchema}].[{TreeTableNameWithoutSchema}]";

			var val = "[val]";

			var result = new StringBuilder($@"
while 1 = 1
begin;
	with {cte} as
	(
		select top 1
			{treeTableFieldNameForId},
			{treeTableFieldNameForParentId},
			{treeTableFieldNameForTreePosition}
		from
			{treeTableName}
		where
			{treeTableFieldNameForTreePosition} = 0
	)
	update {cte} set
		{treeTableFieldNameForTreePosition} = 
		(
			select
				MAX({aliasForTree}.{treeTableFieldNameForTreePosition}) + 10
			from
				{treeTableName} {aliasForTree}
			where
				COALESCE({aliasForTree}.{treeTableFieldNameForParentId}, 0) = COALESCE({cte}.{treeTableFieldNameForParentId}, 0)
		)
	;

	if @@ROWCOUNT < 1 break;
end;

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
update {cte} set
	{treeTableFieldNameForTreeChildCount} = 
	(
		select
			COUNT_BIG(*)
		from
			{treeTableName} {aliasForTree}
		where
			{aliasForTree}.{treeTableFieldNameForParentId} = {cte}.{treeTableFieldNameForId}
	),
	{treeTableFieldNameForTreeDescendantCount} = 
	(
		select
			COUNT_BIG(*)
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
			COUNT_BIG(*) - 1
		from
			{linkTableName} {aliasForLink}
		where
			{aliasForLink}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
	),
	{treeTableFieldNameForTreePath} =
	(
		select
			COALESCE({aliasForResult}.{val}, N'')
		from
		(
			select
				{aliasForLink1}.{linkTableFieldNameForId},
				STUFF
				(
					(
						select
							',' + CONVERT(varchar(max), {aliasForLink2}.{linkTableFieldNameForParentId})
						from
							{linkTableName} {aliasForLink2}
						where
							{aliasForLink1}.{linkTableFieldNameForId} = {aliasForLink2}.{linkTableFieldNameForId}
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} > 0
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} <> {aliasForLink2}.{linkTableFieldNameForId}
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
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
			COALESCE({aliasForResult}.{val}, N'')
		from
		(
			select
				{aliasForLink1}.{linkTableFieldNameForId},
				STUFF
				(
					(
						select
							',' + RIGHT('0000000000' + CONVERT(varchar(max), {aliasForTree}.{treeTableFieldNameForTreePosition}) + '.' + CONVERT(varchar(max), {aliasForLink2}.{linkTableFieldNameForParentId}), 10)
						from
							{linkTableName} {aliasForLink2}
							inner join {treeTableName} {aliasForTree}
								on {aliasForLink2}.{linkTableFieldNameForParentId} = {aliasForTree}.{treeTableFieldNameForId}
						where
							{aliasForLink1}.{linkTableFieldNameForId} = {aliasForLink2}.{linkTableFieldNameForId}
							and
							{aliasForLink2}.{linkTableFieldNameForParentId} > 0
							for xml path(''), type
					).value('.', 'varchar(max)'),
					1,
					1,
					''
				) {val}
			from
				{linkTableName} {aliasForLink1}
			group by
				{aliasForLink1}.{linkTableFieldNameForId}
		) {aliasForResult}
		where
			{aliasForResult}.{linkTableFieldNameForId} = {cte}.{treeTableFieldNameForId}
	)
");
			var parIds = Parameters.Ids;

			if (parIds.Any() || !string.IsNullOrWhiteSpace(SqlForIdsSelectQuery))
			{
				var sqlForIdsSelectQuery = parIds.Any()
					?
					string.Join(", ", parIds.Select(x => x.ParameterName))
					:
					SqlForIdsSelectQuery;

				result.Append($@"
where
	{cte}.{treeTableFieldNameForId} in
	(
		{sqlForIdsSelectQuery}
	)
;
");
			}

			return result.ToString();
		}

		#endregion Public methods
	}
}
