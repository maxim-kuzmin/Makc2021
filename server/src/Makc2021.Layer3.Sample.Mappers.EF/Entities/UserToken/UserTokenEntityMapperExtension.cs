//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserToken;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserToken
{
    /// <summary>
    /// Расширение ORM сущности "UserToken".
    /// </summary>
    public static class UserTokenEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserTokenEntityMapperObject CreateEntityEFObject(
            this UserTokenEntityObject source
            )
        {
            var result = new UserTokenEntityMapperObject();

            new UserTokenEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserTokenEntityObject CreateEntityObject(
            this UserTokenEntityMapperObject source
            )
        {
            var loader = new UserTokenEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
