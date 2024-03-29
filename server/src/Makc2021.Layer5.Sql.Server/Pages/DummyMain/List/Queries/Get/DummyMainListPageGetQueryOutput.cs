﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer4.Sql.Domains.DummyMain.Queries.List.Get;

namespace Makc2021.Layer5.Sql.Server.Pages.DummyMain.List.Queries.Get
{
    /// <summary>
    /// Выходные данные запроса на получение страницы сущностей "DummyMain".
    /// </summary>
    public class DummyMainListPageGetQueryOutput
    {
        #region Properties

        /// <summary>
        /// Список.
        /// </summary>
        public DomainListGetQueryOutput List { get; set; }

        #endregion Properties
    }
}
