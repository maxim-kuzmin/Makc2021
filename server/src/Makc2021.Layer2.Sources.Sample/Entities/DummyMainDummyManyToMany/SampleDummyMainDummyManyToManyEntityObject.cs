//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.Sources.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyMainDummyManyToMany". Объект.
    /// </summary>
    public class SampleDummyMainDummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "DummyMain".
        /// </summary>
        public long ObjectDummyMainId { get; set; }

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        public long ObjectDummyManyToManyId { get; set; }

        #endregion Properties
    }
}
