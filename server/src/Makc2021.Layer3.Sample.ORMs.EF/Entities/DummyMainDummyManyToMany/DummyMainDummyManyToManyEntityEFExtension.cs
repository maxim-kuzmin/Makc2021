//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность "DummyMainDummyManyToMany". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class DummyMainDummyManyToManyEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyMainDummyManyToManyEntityEFObject CreateEntityEFObject(
            this DummyMainDummyManyToManyEntityObject source
            )
        {
            var result = new DummyMainDummyManyToManyEntityEFObject();

            new DummyMainDummyManyToManyEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyMainDummyManyToManyEntityObject CreateEntityObject(
            this DummyMainDummyManyToManyEntityEFObject source
            )
        {
            var loader = new DummyMainDummyManyToManyEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Entity;
        }

        #endregion Public methods
    }
}
