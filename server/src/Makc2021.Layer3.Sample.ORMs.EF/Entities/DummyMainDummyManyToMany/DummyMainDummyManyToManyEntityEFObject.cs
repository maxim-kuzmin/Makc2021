//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMain;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyManyToMany;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность "DummyManyToMany". ORM "Entity Framework". Объект.
    /// </summary>
    public class DummyMainDummyManyToManyEntityEFObject : DummyMainDummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyMain".
        /// </summary>
        public DummyMainEntityEFObject ObjectOfDummyMainEntity { get; set; }

        /// <summary>
        /// Объект сущности "DummyManyToMany".
        /// </summary>
        public DummyManyToManyEntityEFObject ObjectOfDummyManyToManyEntity { get; set; }

        #endregion Properties
    }
}
