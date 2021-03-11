//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Объект ORM сущности "DummyManyToMany".
    /// </summary>
    public class DummyManyToManyEntityMapperObject : DummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<DummyMainDummyManyToManyEntityMapperObject> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<DummyMainDummyManyToManyEntityMapperObject>();

        #endregion Properties
    }
}
