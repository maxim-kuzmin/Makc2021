// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Localization;

namespace Makc2021.Layer4.Domains.DummyMain.Resources.Names
{
    /// <summary>
    /// Ресурс имён в домене.
    /// </summary>
    public class NamesDomainResource : INamesDomainResource
    {
        #region Properties

        private IStringLocalizer<NamesDomainResource> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public NamesDomainResource(IStringLocalizer<NamesDomainResource> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public string GetForItemGetQuery()
        {
            return Localizer["Запрос на получение элемента в домене 'DummyMain'"];
        }

        #endregion Public methods
    }
}
