//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyMain;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain
{
    /// <summary>
    /// Расширение ORM сущности "DummyMain".
    /// </summary>
    public static class DummyMainEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyMainEntityMapperObject CreateEntityEFObject(
            this DummyMainEntityObject source
            )
        {
            var result = new DummyMainEntityMapperObject();

            new DummyMainEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyMainEntityObject CreateEntityObject(
            this DummyMainEntityMapperObject source
            )
        {
            var loader = new DummyMainEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
