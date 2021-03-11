//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyManyToMany;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Расширение ORM сущности "DummyManyToMany".
    /// </summary>
    public static class DummyManyToManyEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyManyToManyEntityMapperObject CreateEntityEFObject(
            this DummyManyToManyEntityObject source
            )
        {
            var result = new DummyManyToManyEntityMapperObject();

            new DummyManyToManyEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyManyToManyEntityObject CreateEntityObject(
            this DummyManyToManyEntityMapperObject source
            )
        {
            var loader = new DummyManyToManyEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
