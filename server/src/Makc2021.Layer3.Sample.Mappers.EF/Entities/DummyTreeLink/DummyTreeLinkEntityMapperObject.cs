//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyTreeLink;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTree;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Объект ORM сущности "DummyTreeLink".
    /// </summary>
    public class DummyTreeLinkEntityMapperObject : DummyTreeLinkEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyTree".
        /// </summary>
        public DummyTreeEntityMapperObject ObjectOfDummyTreeEntity { get; set; }

        #endregion Properties
    }
}
