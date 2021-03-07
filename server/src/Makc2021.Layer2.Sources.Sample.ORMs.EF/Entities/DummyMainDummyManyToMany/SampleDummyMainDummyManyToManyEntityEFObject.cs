//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMain;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyManyToMany;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyManyToMany". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleDummyMainDummyManyToManyEntityEFObject : SampleDummyMainDummyManyToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        public SampleDummyMainEntityEFObject ObjectDummyMain { get; set; }

        /// <summary>
        /// Объект, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        public SampleDummyManyToManyEntityEFObject ObjectDummyManyToMany { get; set; }

        #endregion Properties
    }
}
