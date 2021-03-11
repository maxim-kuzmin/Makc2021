//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.Role;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.Role
{
    /// <summary>
    /// Расширение ORM сущности "Role".
    /// </summary>
    public static class RoleEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static RoleEntityMapperObject CreateEntityEFObject(
            this RoleEntityObject source
            )
        {
            var result = new RoleEntityMapperObject();

            new RoleEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static RoleEntityObject CreateEntityObject(
            this RoleEntityMapperObject source
            )
        {
            var loader = new RoleEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
