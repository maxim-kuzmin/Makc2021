// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;

namespace Makc2021.Layer5.Apps.Server.Pages.DummyMain.Item.Queries.Get
{
    /// <summary>
    /// Входные данные запроса на получение страницы сущности "DummyMain".
    /// </summary>
    public class ItemPageGetQueryInput
    {
        #region Properties

        /// <summary>
        /// Элемент.
        /// </summary>
        public DomainItemGetQueryInput Item { get; } = new();

        #endregion Properties
    }
}
