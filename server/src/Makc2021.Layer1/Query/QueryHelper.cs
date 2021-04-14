// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Помощник запроса.
    /// </summary>
    public class QueryHelper
    {
        #region Public methods

        /// <summary>
        /// Создать код запроса.
        /// </summary>
        /// <returns>Код запроса.</returns>
        public static string CreateQueryCode()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }

        #endregion Public methods
    }
}
