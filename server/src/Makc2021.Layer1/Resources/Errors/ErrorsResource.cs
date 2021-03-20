// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
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

        /// <inheritdoc/>
        public string GetForTypeIsNotImported(Type type)
        {
            string key = string.Format("Тип '{0}' не импортирован", type.FullName);

            return Localizer[key];
        }

        #endregion Public methods
    }
}
