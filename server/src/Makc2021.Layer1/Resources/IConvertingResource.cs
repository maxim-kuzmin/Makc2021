// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Localization;

namespace Makc2021.Layer1.Resources.Converting
{
    /// <summary>
    /// Интерфейс ресурса преобразования.
    /// </summary>
    public interface IConvertingResource
    {
        #region Methods

        /// <summary>
        /// Получить строку "dd.MM.yyyy".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringDateFormat();

        #endregion Methods
    }
}