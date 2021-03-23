// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer2.Query
{
    /// <summary>
    /// Входные данные запроса.
    /// </summary>
    public class QueryInput
    {
        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            return new List<string>();
        }

        #endregion Public methods
    }
}
