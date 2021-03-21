// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Результат запроса.
    /// </summary>
    public class QueryResult
    {
        #region Properties

        /// <summary>
        /// Признак успешности выполнения.
        /// </summary>
        public bool IsOk { get; set; }

        /// <summary>
        /// Сообщения об ошибках.
        /// </summary>
        public HashSet<string> ErrorMessages { get; } = new HashSet<string>();

        /// <summary>
        /// Код запроса.
        /// </summary>
        public string QueryCode { get; set; }

        /// <summary>
        /// Сообщения об успехах.
        /// </summary>
        public HashSet<string> SuccessMessages { get; } = new HashSet<string>();

        /// <summary>
        /// Сообщения о предупреждениях.
        /// </summary>
        public HashSet<string> WarningMessages { get; } = new HashSet<string>();

        #endregion Properties
    }
}
