//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyTreeLink;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTree;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyTreeLink". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleDummyTreeLinkEntityEFObject : SampleDummyTreeLinkEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные родительской сущности "DummyTree".
        /// </summary>
        public SampleDummyTreeEntityEFObject ObjectDummyTree { get; set; }

        #endregion Properties
    }
}
