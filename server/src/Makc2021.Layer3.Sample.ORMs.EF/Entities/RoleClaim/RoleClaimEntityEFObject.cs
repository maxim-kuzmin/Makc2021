//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.RoleClaim;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.Role;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.RoleClaim
{
    /// <summary>
    /// Сущность "RoleClaim". ORM "Entity Framework". Объект.
    /// </summary>
    public class RoleClaimEntityEFObject : RoleClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "Role".
        /// </summary>
        public RoleEntityEFObject ObjectOfRoleEntity { get; set; }

        #endregion Properties
    }
}
