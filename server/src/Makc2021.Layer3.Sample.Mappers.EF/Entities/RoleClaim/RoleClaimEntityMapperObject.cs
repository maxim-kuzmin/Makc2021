//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.RoleClaim;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.Role;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.RoleClaim
{
    /// <summary>
    /// Объект ORM сущности "RoleClaim".
    /// </summary>
    public class RoleClaimEntityMapperObject : RoleClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "Role".
        /// </summary>
        public RoleEntityMapperObject ObjectOfRoleEntity { get; set; }

        #endregion Properties
    }
}
