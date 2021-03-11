//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserRole;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.Role;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.User;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserRole
{
    /// <summary>
    /// Объект ORM сущности "UserRole".
    /// </summary>
    public class UserRoleEntityMapperObject : UserRoleEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "Role".
        /// </summary>
        public RoleEntityMapperObject ObjectOfRoleEntity { get; set; }

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public UserEntityMapperObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
