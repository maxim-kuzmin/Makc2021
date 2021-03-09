//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyTreeLink;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTree;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Сущность "DummyTreeLink". ORM "Entity Framework". Объект.
    /// </summary>
    public class DummyTreeLinkEntityEFObject : DummyTreeLinkEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyTree".
        /// </summary>
        public DummyTreeEntityEFObject ObjectOfDummyTreeEntity { get; set; }

        #endregion Properties
    }
}
