﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer1.Converting
{
    /// <summary>
    /// Интерфейс ресурса преобразования.
    /// </summary>
    public interface IConvertingResource
    {
        #region Methods

        /// <summary>
        /// Получить формат для даты.
        /// </summary>
        /// <returns>Формат.</returns>
        string GetFormatForDate();

        #endregion Methods
    }
}