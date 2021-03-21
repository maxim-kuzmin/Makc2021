﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Ресурс запроса.
    /// </summary>
    public class QueryResource : IQueryResource
    {
        #region Properties

        private IStringLocalizer<QueryResource> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public QueryResource(IStringLocalizer<QueryResource> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public string GetInvalidQueryInputErrorMessage(IEnumerable<string> invalidProperties)
        {
            string invalidPropertiesString = string.Join(", ", invalidProperties);

            string key = string.Format(
                "Входные данные запроса содержит недопустимые значения в свойствах: {0}",
                invalidPropertiesString
                );

            return Localizer[key];
        }

        /// <inheritdoc/>
        public string GetErrorMessageWithCodeAndUrl(string prefix, string code, string url)
        {
            string result = prefix;

            if (!string.IsNullOrWhiteSpace(code))
            {
                string msg = string.Format(Localizer["Код ошибки: {0}"], code);

                result = $"{result}. {msg}";
            }

            if (!string.IsNullOrWhiteSpace(url))
            {
                string msg = string.Format(Localizer["URL: {0}"], url);

                result = $"{result}. {msg}";
            }

            result = result.Replace("!.", "!").Replace("?.", "?");

            return result;
        }

        /// <inheritdoc/>
        public string GetUnknownErrorMessage()
        {
            return Localizer["Неизвестная ошибка"];
        }

        #endregion Public methods
    }
}
