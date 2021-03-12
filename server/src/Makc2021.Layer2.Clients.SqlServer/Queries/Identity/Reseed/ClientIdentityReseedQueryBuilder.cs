﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer2.Queries.Identity.Reseed;
using System.Text;

namespace Makc2021.Layer2.Clients.SqlServer.Queries.Identity.Reseed
{
    /// <summary>
    /// Построитель запроса повторного заполнения идентичности клиента.
    /// </summary>
    public class ClientIdentityReseedQueryBuilder : IdentityReseedQueryBuilder
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
