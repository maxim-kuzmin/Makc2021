//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyManyToMany;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Сущность "DummyManyToMany". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class DummyManyToManyEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyManyToManyEntityEFObject CreateEntityEFObject(
            this DummyManyToManyEntityObject source
            )
        {
            var result = new DummyManyToManyEntityEFObject();

            new DummyManyToManyEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyManyToManyEntityObject CreateEntityObject(
            this DummyManyToManyEntityEFObject source
            )
        {
            var loader = new DummyManyToManyEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
