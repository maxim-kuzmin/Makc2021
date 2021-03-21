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
        /// Получить сообщение об ошибке для типа, который не импортирован.
        /// </summary>
        /// <param name="type">Тип.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetErrorMessageForTypeIsNotImported(Type type);

        #endregion Methods
    }
}
