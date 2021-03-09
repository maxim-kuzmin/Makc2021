//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.User;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserClaim;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserLogin;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserRole;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserToken;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.User
{
    /// <summary>
    /// Сущность "User". ORM "Entity Framework". Объект.
    /// </summary>
    public class UserEntityEFObject : UserEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "UserClaim".
        /// </summary>
        public List<UserClaimEntityEFObject> ObjectsOfUserClaimEntity { get; } =
            new List<UserClaimEntityEFObject>();

        /// <summary>
        /// Объекты сущности "UserLogin".
        /// </summary>
        public List<UserLoginEntityEFObject> ObjectsOfUserLoginEntity { get; } =
            new List<UserLoginEntityEFObject>();

        /// <summary>
        /// Объекты сущности "UserRole".
        /// </summary>
        public List<UserRoleEntityEFObject> ObjectsOfUserRoleEntity { get; } =
            new List<UserRoleEntityEFObject>();

        /// <summary>
        /// Объекты сущности "UserToken".
        /// </summary>
        public List<UserTokenEntityEFObject> ObjectsOfUserTokenEntity { get; } =
            new List<UserTokenEntityEFObject>();

        #endregion Properties
    }
}
