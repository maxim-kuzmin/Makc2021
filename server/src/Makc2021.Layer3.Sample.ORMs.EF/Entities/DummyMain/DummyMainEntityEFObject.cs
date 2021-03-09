//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyMain;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyOneToMany;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMain
{
    /// <summary>
    /// Сущность "DummyMain". ORM "Entity Framework". Объект.
    /// </summary>
    public class DummyMainEntityEFObject : DummyMainEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyOneToMany".
        /// </summary>
        public DummyOneToManyEntityEFObject ObjectOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<DummyMainDummyManyToManyEntityEFObject> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<DummyMainDummyManyToManyEntityEFObject>();

        #endregion Properties
    }
}
