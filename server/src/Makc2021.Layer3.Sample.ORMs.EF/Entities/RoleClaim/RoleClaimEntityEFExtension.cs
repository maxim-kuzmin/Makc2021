//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.RoleClaim;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.RoleClaim
{
    /// <summary>
    /// Сущность "RoleClaim". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class RoleClaimEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static RoleClaimEntityEFObject CreateEntityEFObject(
            this RoleClaimEntityObject source
            )
        {
            var result = new RoleClaimEntityEFObject();

            new RoleClaimEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static RoleClaimEntityObject CreateEntityObject(
            this RoleClaimEntityEFObject source
            )
        {
            var loader = new RoleClaimEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
