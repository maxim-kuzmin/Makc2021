//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyOneToMany;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyOneToMany". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleDummyOneToManyEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyOneToManyEntityEFObject CreateEntityEFObject(
            this SampleDummyOneToManyEntityObject source
            )
        {
            var result = new SampleDummyOneToManyEntityEFObject();

            new SampleDummyOneToManyEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyOneToManyEntityObject CreateEntityObject(
            this SampleDummyOneToManyEntityEFObject source
            )
        {
            var loader = new SampleDummyOneToManyEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
