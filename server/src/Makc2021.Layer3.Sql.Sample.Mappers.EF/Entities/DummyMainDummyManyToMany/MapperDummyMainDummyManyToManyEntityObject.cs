﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Объект сущности "DummyMainDummyManyToMany" сопоставителя.
    /// </summary>
    public class MapperDummyMainDummyManyToManyEntityObject : DummyMainDummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyMain".
        /// </summary>
        public MapperDummyMainEntityObject ObjectOfDummyMainEntity { get; set; }

        /// <summary>
        /// Объект сущности "DummyManyToMany".
        /// </summary>
        public MapperDummyManyToManyEntityObject ObjectOfDummyManyToManyEntity { get; set; }

        #endregion Properties
    }
}
