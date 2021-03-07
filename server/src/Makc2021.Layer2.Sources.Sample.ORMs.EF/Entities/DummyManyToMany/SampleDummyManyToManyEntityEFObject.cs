//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyManyToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany;
using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyManyToMany". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleDummyManyToManyEntityEFObject : SampleDummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyMainDummyManyToMany".
        /// </summary>
        public List<SampleDummyMainDummyManyToManyEntityEFObject> ObjectsDummyMainDummyManyToMany { get; } =
            new List<SampleDummyMainDummyManyToManyEntityEFObject>();

        #endregion Properties
    }
}
