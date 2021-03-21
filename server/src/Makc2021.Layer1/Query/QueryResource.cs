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
        public string GetErrorMessageForDefault()
        {
            return Localizer["Неизвестная ошибка"];
        }

        /// <inheritdoc/>
        public string GetErrorMessageForInvalidInput(IEnumerable<string> invalidProperties)
        {
            string invalidPropertiesString = string.Join(", ", invalidProperties);

            string key = string.Format(
                "Входные данные запроса содержит недопустимые значения в свойствах: {0}",
                invalidPropertiesString
                );

            return Localizer[key];
        }

        /// <inheritdoc/>
        public string GetErrorMessageWithCode(string errorMessage, string code)
        {
            string errorCode = string.Format(Localizer["Код ошибки: {0}"], code);

            return $"{errorMessage}. {errorCode}".Replace("!.", "!").Replace("?.", "?");
        }

        /// <inheritdoc/>
        public string GetTitleForError()
        {
            return Localizer["Ошибка"];
        }

        /// <inheritdoc/>
        public string GetTitleForInput()
        {
            return Localizer["Входные данные"];
        }

        /// <inheritdoc/>
        public string GetTitleForQueryCode()
        {
            return Localizer["Код запроса"];
        }    

        /// <inheritdoc/>
        public string GetTitleForResult()
        {
            return Localizer["Результат"];
        }

        /// <inheritdoc/>
        public string GetTitleForStart()
        {
            return Localizer["Начало"];
        }

        /// <inheritdoc/>
        public string GetTitleForSuccess()
        {
            return Localizer["Успех"];
        }

        #endregion Public methods
    }
}
