//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Queries.Identity.Reseed;
using System.Text;

namespace Makc2021.Layer2.DBs.SqlServer.Queries.Identity.Reseed
{
    /// <summary>
    /// База данных "Microsoft SQL Server". Запрос перезаполнения идентичности. Построитель.
    /// </summary>
    public class SqlServerIdentityReseedQueryBuilder : IdentityReseedQueryBuilder
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
			var result = new StringBuilder();

            foreach (var input in Inputs)
            {
                result.Append($@"
DBCC CHECKIDENT ('{input.Schema}.{input.Table}', RESEED, 0);
");
            }

            return result.ToString();
        }

        #endregion Public methods
    }
}
