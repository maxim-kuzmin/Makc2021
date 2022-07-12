// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.DummyManyToMany;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;

using System.Collections.Generic;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Объект сущности "DummyManyToMany" сопоставителя.
    /// </summary>
    public class MapperDummyManyToManyEntityObject : DummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<MapperDummyMainDummyManyToManyEntityObject> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<MapperDummyMainDummyManyToManyEntityObject>();

        #endregion Properties
    }
}
