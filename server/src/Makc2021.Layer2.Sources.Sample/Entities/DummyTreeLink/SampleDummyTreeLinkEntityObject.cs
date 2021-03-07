//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.Sources.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyTreeLink". Объект.
    /// </summary>
    public class SampleDummyTreeLinkEntityObject
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
