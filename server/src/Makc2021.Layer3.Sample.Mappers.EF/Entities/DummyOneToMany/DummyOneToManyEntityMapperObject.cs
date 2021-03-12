// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyOneToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Объект ORM сущности "DummyOneToMany".
    /// </summary>
    public class DummyOneToManyEntityMapperObject : DummyOneToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMain".
        /// </summary>
        public List<DummyMainEntityMapperObject> ObjectsOfDummyMainEntity { get; } =
            new List<DummyMainEntityMapperObject>();

        #endregion Properties
    }
}
