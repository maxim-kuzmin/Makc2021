// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.RoleClaim;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.Role;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.RoleClaim
{
    /// <summary>
    /// Объект сущности "RoleClaim" для сопоставителя.
    /// </summary>
    public class MapperRoleClaimEntityObject : RoleClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "Role".
        /// </summary>
        public MapperRoleEntityObject ObjectOfRoleEntity { get; set; }

        #endregion Properties
    }
}
