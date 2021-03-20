// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Localization;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get
{
    /// <summary>
    /// Интерфейс ресурса запроса на получение элемента в домене.
    /// </summary>
    public class ItemGetQueryDomainResource : IItemGetQueryDomainResource
    {
        #region Properties

        private IStringLocalizer<ItemGetQueryDomainResource> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ItemGetQueryDomainResource(IStringLocalizer<ItemGetQueryDomainResource> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public string GetQueryName()
        {
            return Localizer["Запрос на получение элемента в домене 'DummyMain'"];
        }

        #endregion Public methods
    }
}
