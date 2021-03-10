//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.Role;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.Role
{
    /// <summary>
    /// Сущность "Role". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class RoleEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static RoleEntityEFObject CreateEntityEFObject(
            this RoleEntityObject source
            )
        {
            var result = new RoleEntityEFObject();

            new RoleEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static RoleEntityObject CreateEntityObject(
            this RoleEntityEFObject source
            )
        {
            var loader = new RoleEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Entity;
        }

        #endregion Public methods
    }
}
