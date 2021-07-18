// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyMain;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany;

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain
{
    /// <summary>
    /// Объект сущности "DummyMain" сопоставителя.
    /// </summary>
    public class MapperDummyMainEntityObject : DummyMainEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyOneToMany".
        /// </summary>
        public MapperDummyOneToManyEntityObject ObjectOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<MapperDummyMainDummyManyToManyEntityObject> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<MapperDummyMainDummyManyToManyEntityObject>();

        #endregion Properties
    }
}
