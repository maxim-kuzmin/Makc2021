//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyMain;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMain
{
    /// <summary>
    /// Сущность "DummyMain". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class DummyMainEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyMainEntityEFObject CreateEntityEFObject(
            this DummyMainEntityObject source
            )
        {
            var result = new DummyMainEntityEFObject();

            new DummyMainEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyMainEntityObject CreateEntityObject(
            this DummyMainEntityEFObject source
            )
        {
            var loader = new DummyMainEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Entity;
        }

        #endregion Public methods
    }
}
