// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;

namespace Makc2021.Layer5.Apps.API.Pages.DummyMain.Item.Queries.Get
{
    /// <summary>
    /// Входные данные запроса на получение страницы сущности "DummyMain".
    /// </summary>
    public class DummyMainItemPageGetQueryInput
    {
        #region Properties

        /// <summary>
        /// Элемент.
        /// </summary>
        public ItemGetQueryDomainInput Item { get; } = new();

        #endregion Properties
    }
}
