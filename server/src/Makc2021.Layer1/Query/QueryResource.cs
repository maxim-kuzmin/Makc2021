// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

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
        public string GetStringUnknownError()
        {
            return Localizer["Неизвестная ошибка"];
        }

        /// <inheritdoc/>
        public string GetStringFormatMessageWithCode()
        {
            return Localizer["{0}. Код ошибки: {1}"];
        }

        /// <inheritdoc/>
        public string GetStringFormatMessagePartWithUrl()
        {
            return Localizer[". URL: {2}"];
        }

        /// <inheritdoc/>
        public string GetForIvalidQueryInput(IEnumerable<string> invalidProperties)
        {
            string invalidPropertiesString = string.Join(", ", invalidProperties);

            string key = string.Format(
                "Входные данные запроса содержит недопустимые значения в свойствах: {0}",
                invalidPropertiesString
                );

            return Localizer[key];
        }

        #endregion Public methods
    }
}
