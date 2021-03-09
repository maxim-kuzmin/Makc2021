//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Сущность "DummyManyToMany". ORM "Entity Framework". Объект.
    /// </summary>
    public class DummyManyToManyEntityEFObject : DummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<DummyMainDummyManyToManyEntityEFObject> ObjectsOfDummyMainDummyManyToManyEntity { get; } =
            new List<DummyMainDummyManyToManyEntityEFObject>();

        #endregion Properties
    }
}
