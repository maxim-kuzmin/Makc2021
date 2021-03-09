//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyTree;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTreeLink;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTree
{
    /// <summary>
    /// Сущность "DummyTree". ORM "Entity Framework". Объект.
    /// </summary>
    public class DummyTreeEntityEFObject : DummyTreeEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект родителя сущности "DummyTree".
        /// </summary>
        public DummyTreeEntityEFObject ObjectOfDummyTreeEntityParent { get; set; }

        /// <summary>
        /// Объекты ребёнка сущности "DummyTree".
        /// </summary>
        public List<DummyTreeEntityEFObject> ObjectsOfDummyTreeEntityChild { get; } =
            new List<DummyTreeEntityEFObject>();

        /// <summary>
        /// Объекты сущности "DummyTreeLink".
        /// </summary>
        public List<DummyTreeLinkEntityEFObject> ObjectsOfDummyTreeLinkEntity { get; } =
            new List<DummyTreeLinkEntityEFObject>();

        #endregion Properties
    }
}
