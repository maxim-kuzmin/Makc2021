//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserLogin;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserLogin
{
    /// <summary>
    /// Сущность "UserLogin". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class UserLoginEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserLoginEntityEFObject CreateEntityEFObject(
            this UserLoginEntityObject source
            )
        {
            var result = new UserLoginEntityEFObject();

            new UserLoginEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserLoginEntityObject CreateEntityObject(
            this UserLoginEntityEFObject source
            )
        {
            var loader = new UserLoginEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Entity;
        }

        #endregion Public methods
    }
}
