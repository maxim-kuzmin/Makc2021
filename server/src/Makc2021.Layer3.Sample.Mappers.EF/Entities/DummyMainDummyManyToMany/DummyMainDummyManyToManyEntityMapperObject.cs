//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Объект ORM сущности "DummyMainDummyManyToMany".
    /// </summary>
    public class DummyMainDummyManyToManyEntityMapperObject : DummyMainDummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyMain".
        /// </summary>
        public DummyMainEntityMapperObject ObjectOfDummyMainEntity { get; set; }

        /// <summary>
        /// Объект сущности "DummyManyToMany".
        /// </summary>
        public DummyManyToManyEntityMapperObject ObjectOfDummyManyToManyEntity { get; set; }

        #endregion Properties
    }
}
