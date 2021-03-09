//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Сущность "DummyTreeLink". Объект.
    /// </summary>
    public class DummyTreeLinkEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор узла.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор родительского узла.
        /// </summary>
        public long ParentId { get; set; }

        #endregion Properties
    }
}
