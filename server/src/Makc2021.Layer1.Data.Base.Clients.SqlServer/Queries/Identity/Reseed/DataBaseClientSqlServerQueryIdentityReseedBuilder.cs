//Author Maxim Kuzmin//makc//

using Makc2021.Layer1.Data.Base.Queries.Identity.Reseed;
using System.Text;

namespace Makc2021.Layer1.Data.Base.Clients.SqlServer.Queries.Identity.Reseed
{
    /// <summary>
    /// Данные. Основа. Клиенты. SQL Server. Запросы. Идентичность. Перезаполнение. Построитель.
    /// </summary>
    public class DataBaseClientSqlServerQueryIdentityReseedBuilder : DataBaseQueryIdentityReseedBuilder
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
