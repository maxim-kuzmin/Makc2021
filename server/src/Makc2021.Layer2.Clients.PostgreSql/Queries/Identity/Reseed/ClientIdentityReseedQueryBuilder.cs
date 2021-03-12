// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Text;
using Makc2021.Layer2.Queries.Identity.Reseed;

namespace Makc2021.Layer2.Clients.PostgreSql.Queries.Identity.Reseed
{
    /// <summary>
    /// База данных "PostgreSQL". Запрос перезаполнения идентичности. Построитель.
    /// </summary>
    public class ClientIdentityReseedQueryBuilder : IdentityReseedQueryBuilder
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
            StringBuilder result = new();

            foreach (IdentityReseedQueryInput input in Inputs)
            {
                foreach (string column in input.Columns)
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
