//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyTree;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTreeLink;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTree
{
    /// <summary>
    /// Объект ORM сущности "DummyTree".
    /// </summary>
    public class DummyTreeEntityMapperObject : DummyTreeEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект родителя сущности "DummyTree".
        /// </summary>
        public DummyTreeEntityMapperObject ObjectOfDummyTreeEntityParent { get; set; }

        /// <summary>
        /// Объекты ребёнка сущности "DummyTree".
        /// </summary>
        public List<DummyTreeEntityMapperObject> ObjectsOfDummyTreeEntityChild { get; } =
            new List<DummyTreeEntityMapperObject>();

        /// <summary>
        /// Объекты сущности "DummyTreeLink".
        /// </summary>
        public List<DummyTreeLinkEntityMapperObject> ObjectsOfDummyTreeLinkEntity { get; } =
            new List<DummyTreeLinkEntityMapperObject>();

        #endregion Properties
    }
}
