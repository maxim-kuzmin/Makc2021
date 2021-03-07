//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyMainDummyManyToMany;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyMainDummyManyToMany". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleDummyMainDummyManyToManyEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyMainDummyManyToManyEntityEFObject CreateEntityEFObject(
            this SampleDummyMainDummyManyToManyEntityObject source
            )
        {
            var result = new SampleDummyMainDummyManyToManyEntityEFObject();

            new SampleDummyMainDummyManyToManyEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyMainDummyManyToManyEntityObject CreateEntityObject(
            this SampleDummyMainDummyManyToManyEntityEFObject source
            )
        {
            var loader = new SampleDummyMainDummyManyToManyEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
