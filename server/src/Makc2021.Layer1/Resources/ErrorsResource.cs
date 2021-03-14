// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Localization;

namespace Makc2021.Layer1.Resources.Errors
{
    /// <summary>
    /// Ресурс ошибок.
    /// </summary>
    public class ErrorsResource : IErrorsResource
    {
        #region Properties

        private IStringLocalizer<ErrorsResource> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ErrorsResource(IStringLocalizer<ErrorsResource> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку форматирования ". URL: {2}".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatMessagePartWithUrl()
        {
            return Localizer[". URL: {2}"];
        }

        /// <summary>
        /// Получить строку форматирования "{0}. Код ошибки: {1}".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatMessageWithCode()
        {
            return Localizer["{0}. Код ошибки: {1}"];
        }

        /// <summary>
        /// Получить строку "Доступ запрещён".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringHttp403()
        {
            return Localizer["Доступ запрещён"];
        }

        /// <summary>
        /// Получить строку "Страница не найдена".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringHttp404()
        {
            return Localizer["Страница не найдена"];
        }

        /// <summary>
        /// Получить строку "Неизвестная ошибка".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringUnknownError()
        {
            return Localizer["Неизвестная ошибка"];
        }

        /// <summary>
        /// Получить строку "Ввод содержит недопустимые значения в свойствах: {0}".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatMessageIvalidInput()
        {
            return Localizer["Ввод содержит недопустимые значения в свойствах: {0}"];
        }

        #endregion Public methods
    }
}
