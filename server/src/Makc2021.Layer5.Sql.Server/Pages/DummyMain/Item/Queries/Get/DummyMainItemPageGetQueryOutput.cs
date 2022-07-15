// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using DummyMainDomainItemGetQueryOutput = Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get.DomainItemGetQueryOutput;

namespace Makc2021.Layer5.Sql.Server.Pages.DummyMain.Item.Queries.Get
{
    /// <summary>
    /// Выходные данные запроса на получение страницы сущности "DummyMain".
    /// </summary>
    public class DummyMainItemPageGetQueryOutput
    {
        #region Properties

        /// <summary>
        /// Выходные данные запроса на получение элемента в домене "DummyMain".
        /// </summary>
        public DummyMainDomainItemGetQueryOutput OutputOfDummyMainDomainItemGetQuery { get; set; }

        #endregion Properties
    }
}
