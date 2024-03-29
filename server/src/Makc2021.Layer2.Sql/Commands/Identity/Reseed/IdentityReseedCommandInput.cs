﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer2.Sql.Commands.Identity.Reseed
{
    /// <summary>
    /// Ввод команды на повторное заполнение идентичности.
    /// </summary>
    public class IdentityReseedCommandInput
    {
        #region Properties

        /// <summary>
        /// Имена столбцов.
        /// </summary>
        public IEnumerable<string> Columns { get; private set; }

        /// <summary>
        /// Имя таблицы.
        /// </summary>
        public string Table { get; private set; }

        /// <summary>
        /// Схема.
        /// </summary>
        public string Schema { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Получить результирующий SQL.
        /// </summary>
        public IdentityReseedCommandInput(
            string table,
            string schema,
            params string[] columns
            )
        {
            Table = table;
            Schema = schema;
            Columns = columns;
        }

        #endregion Constructors
    }
}
