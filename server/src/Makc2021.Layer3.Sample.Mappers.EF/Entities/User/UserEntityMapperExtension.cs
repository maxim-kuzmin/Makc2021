//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.User;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.User
{
    /// <summary>
    /// Расширение ORM сущности "User".
    /// </summary>
    public static class UserEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserEntityMapperObject CreateEntityEFObject(
            this UserEntityObject source
            )
        {
            var result = new UserEntityMapperObject();

            new UserEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserEntityObject CreateEntityObject(
            this UserEntityMapperObject source
            )
        {
            var loader = new UserEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
