// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyMain;
using Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.Entities.DummyOneToMany;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get
{
    /// <summary>
    /// Вывод запроса на получение элемента в домене.
    /// </summary>
    public class ItemGetQueryDomainOutput
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyMain".
        /// </summary>
        public DummyMainEntityObject ObjectOfDummyMainEntity { get; set; }

        /// <summary>
        /// Объекты сущности "DummyManyToMany".
        /// </summary>
        public DummyManyToManyEntityObject[] ObjectsOfDummyManyToManyEntity { get; set; }

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public DummyMainDummyManyToManyEntityObject[] ObjectsOfDummyMainDummyManyToManyEntity { get; set; }

        /// <summary>
        /// Объект сущности "DummyOneToMany".
        /// </summary>
        public DummyOneToManyEntityObject ObjectOfDummyOneToManyEntity { get; set; }

        #endregion Properties
    }
}
