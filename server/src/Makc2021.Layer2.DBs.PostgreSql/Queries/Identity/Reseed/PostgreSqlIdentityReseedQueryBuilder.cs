﻿//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Queries.Identity.Reseed;
using System.Text;

namespace Makc2021.Layer2.DBs.PostgreSql.Queries.Identity.Reseed
{
    /// <summary>
    /// База данных "PostgreSQL". Запрос перезаполнения идентичности. Построитель.
    /// </summary>
    public class PostgreSqlIdentityReseedQueryBuilder : IdentityReseedQueryBuilder
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