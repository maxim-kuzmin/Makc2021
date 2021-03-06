//Author Maxim Kuzmin//makc//

using Makc2021.Layer1.Data.Base.Queries.Identity.Reseed;
using System.Text;

namespace Makc2021.Layer1.Data.Base.Clients.PostgreSql.Queries.Identity.Reseed
{
    /// <summary>
    /// Данные. Основа. Клиенты. PostgreSQL. Запросы. Идентичность. Перезаполнение. Построитель.
    /// </summary>
    public class DataBaseClientPostgreSqlQueryIdentityReseedBuilder : DataBaseQueryIdentityReseedBuilder
	{
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
			var result = new StringBuilder();

            foreach (var input in Inputs)
            {
                foreach (var column in input.Columns)
                {
                    result.Append($@"
SELECT setval(pg_get_serial_sequence('""{input.Schema}"".""{input.Table}""', '{column}'), 1);
");
                }
            }

            return result.ToString();
        }

        #endregion Public methods
    }
}
