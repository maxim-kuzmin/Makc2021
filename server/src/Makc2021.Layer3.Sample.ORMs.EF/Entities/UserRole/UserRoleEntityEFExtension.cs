//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserRole;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserRole
{
    /// <summary>
    /// Сущность "UserRole". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class UserRoleEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserRoleEntityEFObject CreateEntityEFObject(
            this UserRoleEntityObject source
            )
        {
            var result = new UserRoleEntityEFObject();

            new UserRoleEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserRoleEntityObject CreateEntityObject(
            this UserRoleEntityEFObject source
            )
        {
            var loader = new UserRoleEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Entity;
        }

        #endregion Public methods
    }
}
