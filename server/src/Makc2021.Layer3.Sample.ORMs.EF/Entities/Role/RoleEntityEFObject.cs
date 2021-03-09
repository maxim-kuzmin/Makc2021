//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.Role;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.RoleClaim;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserRole;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.Role
{
    /// <summary>
    /// Сущность "Role". ORM "Entity Framework". Объект.
    /// </summary>
    public class RoleEntityEFObject : RoleEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "RoleClaim".
        /// </summary>
        public List<RoleClaimEntityEFObject> ObjectsOfRoleClaimEntity { get; } =
            new List<RoleClaimEntityEFObject>();

        /// <summary>
        /// Объекты сущности "UserRole".
        /// </summary>
        public List<UserRoleEntityEFObject> ObjectsOfUserRoleEntity { get; } =
            new List<UserRoleEntityEFObject>();

        #endregion Properties
    }
}
