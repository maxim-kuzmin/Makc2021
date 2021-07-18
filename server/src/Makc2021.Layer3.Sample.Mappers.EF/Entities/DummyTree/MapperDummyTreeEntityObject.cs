// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyTree;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTreeLink;

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTree
{
    /// <summary>
    /// Объект сущности "DummyTree" сопоставителя.
    /// </summary>
    public class MapperDummyTreeEntityObject : DummyTreeEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект родителя сущности "DummyTree".
        /// </summary>
        public MapperDummyTreeEntityObject ObjectOfDummyTreeEntityParent { get; set; }

        /// <summary>
        /// Объекты ребёнка сущности "DummyTree".
        /// </summary>
        public List<MapperDummyTreeEntityObject> ObjectsOfDummyTreeEntityChild { get; } =
            new List<MapperDummyTreeEntityObject>();

        /// <summary>
        /// Объекты сущности "DummyTreeLink".
        /// </summary>
        public List<MapperDummyTreeLinkEntityObject> ObjectsOfDummyTreeLinkEntity { get; } =
            new List<MapperDummyTreeLinkEntityObject>();

        #endregion Properties
    }
}
