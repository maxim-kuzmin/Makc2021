// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Localization;

namespace Makc2021.Layer1.Resources.Converting
{
    /// <summary>
    /// Ресурс преобразования.
    /// </summary>
    public class ConvertingResource : IConvertingResource
    {
        #region Properties

        private IStringLocalizer<ConvertingResource> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ConvertingResource(IStringLocalizer<ConvertingResource> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "dd.MM.yyyy".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringDateFormat()
        {
            return Localizer["dd.MM.yyyy"];
        }

        #endregion Public methods
    }
}