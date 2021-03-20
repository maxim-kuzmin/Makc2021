// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Localization;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.List.Get
{
    /// <summary>
    /// Интерфейс ресурса запроса на получение списка в домене.
    /// </summary>
    public class ListGetQueryDomainResource : IListGetQueryDomainResource
    {
        #region Properties

        private IStringLocalizer<ListGetQueryDomainResource> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public ListGetQueryDomainResource(IStringLocalizer<ListGetQueryDomainResource> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public string GetQueryName()
        {
            return Localizer["Запрос на получение списка в домене 'DummyMain'"];
        }

        #endregion Public methods
    }
}
