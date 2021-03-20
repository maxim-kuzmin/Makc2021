// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2021.Layer1.Resources.Errors
{
    /// <summary>
    /// Интерфейс ресурса ошибок.
    /// </summary>
    public interface IErrorsResource
    {
        #region Methods

        /// <summary>
        /// Получить строку "Доступ запрещён".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringHttp403();

        /// <summary>
        /// Получить строку "Страница не найдена".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringHttp404();

        /// <summary>
        /// Получить сообщение для исключения, возникающего в случае, если тип не импортирован.
        /// </summary>
        /// <param name="type">Тип.</param>
        /// <returns>Сообщение.</returns>
        string GetForTypeIsNotImported(Type type);

        #endregion Methods
    }
}
