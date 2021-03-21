// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2021.Layer1.Common
{
    /// <summary>
    /// Интерфейс общего ресурса.
    /// </summary>
    public interface ICommonResource
    {
        #region Methods

        /// <summary>
        /// Получить сообщение об ошибке при попытке использования неимпортированного типа.
        /// </summary>
        /// <param name="type">Тип.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetTypeIsNotImportedErrorMessage(Type type);

        #endregion Methods
    }
}
