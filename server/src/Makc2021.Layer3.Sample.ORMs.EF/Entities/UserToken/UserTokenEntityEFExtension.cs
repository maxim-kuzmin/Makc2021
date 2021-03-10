//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserToken;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserToken
{
    /// <summary>
    /// Сущность "UserToken". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class UserTokenEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserTokenEntityEFObject CreateEntityEFObject(
            this UserTokenEntityObject source
            )
        {
            var result = new UserTokenEntityEFObject();

            new UserTokenEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserTokenEntityObject CreateEntityObject(
            this UserTokenEntityEFObject source
            )
        {
            var loader = new UserTokenEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Entity;
        }

        #endregion Public methods
    }
}
