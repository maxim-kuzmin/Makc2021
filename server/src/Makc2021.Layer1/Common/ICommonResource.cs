// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Makc2021.Layer1.Common
{
    /// <summary>
    /// Интерфейс общего ресурса.
    /// </summary>
    public interface ICommonResource
    {
        #region Methods

        /// <summary>
        /// Получить сообщение об ошибке для не импортированных типов.
        /// </summary>
        /// <param name="types">Типы.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetErrorMessageForNotImportedTypes(IEnumerable<Type> types);

        #endregion Methods
    }
}
