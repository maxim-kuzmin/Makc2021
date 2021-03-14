// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer1.Resources.Errors
{
    /// <summary>
    /// Интерфейс ресурса ошибок.
    /// </summary>
    public interface IErrorsResource
    {
        #region Methods

        /// <summary>
        /// Получить строку форматирования ". URL: {2}".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringFormatMessagePartWithUrl();

        /// <summary>
        /// Получить строку форматирования "{0}. Код ошибки: {1}".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringFormatMessageWithCode();

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
        /// Получить строку "Неизвестная ошибка".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringUnknownError();

        /// <summary>
        /// Получить строку "Ввод содержит недопустимые значения в свойствах: {0}".
        /// </summary>
        /// <returns>Строка.</returns>
        string GetStringFormatMessageIvalidInput();

        #endregion Methods
    }
}
