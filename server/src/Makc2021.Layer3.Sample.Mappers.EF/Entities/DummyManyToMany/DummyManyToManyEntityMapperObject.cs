// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Объект сущности "DummyManyToMany" для сопоставителя.
    /// </summary>
    public class DummyManyToManyEntityMapperObject : DummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<DummyMainDummyManyToManyEntityMapperObject> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<DummyMainDummyManyToManyEntityMapperObject>();

        #endregion Properties
    }
}
