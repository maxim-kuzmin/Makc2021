//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyMain;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyOneToMany;
using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMain
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyMain". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleDummyMainEntityEFObject : SampleDummyMainEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "DummyOneToMany".
        /// </summary>
        public SampleDummyOneToManyEntityEFObject ObjectDummyOneToMany { get; set; }

        /// <summary>
        /// Объекты сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<SampleDummyMainDummyManyToManyEntityEFObject> ObjectsDummyMainDummyManyToMany { get; } =
            new List<SampleDummyMainDummyManyToManyEntityEFObject>();

        #endregion Properties
    }
}
