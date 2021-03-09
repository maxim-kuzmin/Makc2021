//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность "DummyMainDummyManyToMany". Объект.
    /// </summary>
    public class DummyMainDummyManyToManyEntityObject
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
