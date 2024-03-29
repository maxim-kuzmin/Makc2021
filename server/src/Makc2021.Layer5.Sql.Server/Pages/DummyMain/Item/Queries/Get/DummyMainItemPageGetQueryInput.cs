﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using DummyMainDomainItemGetQueryInput = Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get.DomainItemGetQueryInput;

namespace Makc2021.Layer5.Sql.Server.Pages.DummyMain.Item.Queries.Get
{
    /// <summary>
    /// Входные данные запроса на получение страницы сущности "DummyMain".
    /// </summary>
    public class DummyMainItemPageGetQueryInput
    {
        #region Properties

        /// <summary>
        /// Входные данные запроса на получение элемента в домене "DummyMain".
        /// </summary>
        public DummyMainDomainItemGetQueryInput InputOfDummyMainDomainItemGetQuery { get; } = new();

        #endregion Properties
    }
}
