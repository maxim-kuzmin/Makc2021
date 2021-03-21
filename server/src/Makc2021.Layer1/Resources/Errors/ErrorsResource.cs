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

        /// <inheritdoc/>
        public string GetHttp403ErrorMessage()
        {
            return Localizer["Доступ запрещён"];
        }

        /// <inheritdoc/>
        public string GetHttp404ErrorMessage()
        {
            return Localizer["Страница не найдена"];
        }

        /// <inheritdoc/>
        public string GetTypeIsNotImportedErrorMessage(Type type)
        {
            string key = string.Format("Тип '{0}' не импортирован", type.FullName);

            return Localizer[key];
        }

        #endregion Public methods
    }
}
