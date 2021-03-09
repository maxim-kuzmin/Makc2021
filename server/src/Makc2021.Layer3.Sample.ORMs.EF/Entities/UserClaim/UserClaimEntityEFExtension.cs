//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserClaim;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserClaim
{
    /// <summary>
    /// Сущность "UserClaim". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class UserClaimEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserClaimEntityEFObject CreateEntityEFObject(
            this UserClaimEntityObject source
            )
        {
            var result = new UserClaimEntityEFObject();

            new UserClaimEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserClaimEntityObject CreateEntityObject(
            this UserClaimEntityEFObject source
            )
        {
            var loader = new UserClaimEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
