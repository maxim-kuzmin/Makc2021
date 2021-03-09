//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserRole;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.Role;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.User;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserRole
{
    /// <summary>
    /// Сущность "UserRole". ORM "Entity Framework". Объект.
    /// </summary>
    public class UserRoleEntityEFObject : UserRoleEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "Role".
        /// </summary>
        public RoleEntityEFObject ObjectOfRoleEntity { get; set; }

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public UserEntityEFObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
