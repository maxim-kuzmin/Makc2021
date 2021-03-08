//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyTree;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTreeLink;
using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTree
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyTree". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleDummyTreeEntityEFObject : SampleDummyTreeEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные родительской сущности "DummyTree".
        /// </summary>
        public SampleDummyTreeEntityEFObject ObjectDummyTreeParent { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные дочерней сущности "DummyTree".
        /// </summary>
        public List<SampleDummyTreeEntityEFObject> ObjectsDummyTreeChild { get; } =
            new List<SampleDummyTreeEntityEFObject>();

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyTreeLink".
        /// </summary>
        public List<SampleDummyTreeLinkEntityEFObject> ObjectsDummyTreeLink { get; } =
            new List<SampleDummyTreeLinkEntityEFObject>();

        #endregion Properties
    }
}
