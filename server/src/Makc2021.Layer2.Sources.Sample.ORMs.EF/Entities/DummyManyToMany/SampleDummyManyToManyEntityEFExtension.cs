//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyManyToMany;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyManyToMany". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleDummyManyToManyEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyManyToManyEntityEFObject CreateEntityEFObject(
            this SampleDummyManyToManyEntityObject source
            )
        {
            var result = new SampleDummyManyToManyEntityEFObject();

            new SampleDummyManyToManyEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyManyToManyEntityObject CreateEntityObject(
            this SampleDummyManyToManyEntityEFObject source
            )
        {
            var loader = new SampleDummyManyToManyEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
