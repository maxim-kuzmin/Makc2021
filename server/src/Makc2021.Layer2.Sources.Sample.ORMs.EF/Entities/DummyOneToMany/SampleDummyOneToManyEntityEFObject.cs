//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyOneToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMain;
using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyOneToMany". ORM "Entity Framework". Объект.
    /// </summary>
    public class SampleDummyOneToManyEntityEFObject : SampleDummyOneToManyEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyMain".
        /// </summary>
        public List<SampleDummyMainEntityEFObject> ObjectsDummyMain { get; } =
            new List<SampleDummyMainEntityEFObject>();

        #endregion Properties
    }
}
