//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyOneToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMain;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Сущность "DummyOneToMany". ORM "Entity Framework". Объект.
    /// </summary>
    public class DummyOneToManyEntityEFObject : DummyOneToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "DummyMain".
        /// </summary>
        public List<DummyMainEntityEFObject> ObjectsOfDummyMainEntity { get; } =
            new List<DummyMainEntityEFObject>();

        #endregion Properties
    }
}
