//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyOneToMany;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Сущность "DummyOneToMany". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class DummyOneToManyEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyOneToManyEntityEFObject CreateEntityEFObject(
            this DummyOneToManyEntityObject source
            )
        {
            var result = new DummyOneToManyEntityEFObject();

            new DummyOneToManyEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyOneToManyEntityObject CreateEntityObject(
            this DummyOneToManyEntityEFObject source
            )
        {
            var loader = new DummyOneToManyEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
