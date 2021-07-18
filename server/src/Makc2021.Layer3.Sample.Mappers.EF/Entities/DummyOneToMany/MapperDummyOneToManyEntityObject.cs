// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyOneToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Объект сущности "DummyOneToMany" сопоставителя.
    /// </summary>
    public class MapperDummyOneToManyEntityObject : DummyOneToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMain".
        /// </summary>
        public List<MapperDummyMainEntityObject> ObjectsOfDummyMainEntity { get; } =
            new List<MapperDummyMainEntityObject>();

        #endregion Properties
    }
}
