﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Text;
using Makc2021.Layer2.Sql.Commands.Identity.Reseed;

namespace Makc2021.Layer2.Sql.Clients.SqlServer.Commands.Identity.Reseed
{
    /// <summary>
    /// Построитель команды на повторное заполнение идентичности у клиента.
    /// </summary>
    public class IdentityReseedCommandClientBuilder : IdentityReseedCommandBuilder
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override string GetResultSql()
        {
            StringBuilder result = new();

            foreach (IdentityReseedCommandInput input in Inputs)
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
