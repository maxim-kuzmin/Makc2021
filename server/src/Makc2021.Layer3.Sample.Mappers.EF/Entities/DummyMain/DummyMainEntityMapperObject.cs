//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyMain;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain
{
    /// <summary>
    /// Объект ORM сущности "DummyMain".
    /// </summary>
    public class DummyMainEntityMapperObject : DummyMainEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyOneToMany".
        /// </summary>
        public DummyOneToManyEntityMapperObject ObjectOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<DummyMainDummyManyToManyEntityMapperObject> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<DummyMainDummyManyToManyEntityMapperObject>();

        #endregion Properties
    }
}
