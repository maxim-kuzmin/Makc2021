//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserClaim;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.User;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserClaim
{
    /// <summary>
    /// Сущность "UserClaim". ORM "Entity Framework". Объект.
    /// </summary>
    public class UserClaimEntityEFObject : UserClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public UserEntityEFObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
