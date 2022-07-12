// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.Role;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole;

using System.Collections.Generic;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.Role
{
    /// <summary>
    /// Объект сущности "Role" для сопоставителя.
    /// </summary>
    public class MapperRoleEntityObject : RoleEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "RoleClaim".
        /// </summary>
        public List<MapperRoleClaimEntityObject> ObjectsOfRoleClaimEntity { get; } =
            new List<MapperRoleClaimEntityObject>();

        /// <summary>
        /// Объекты сущности "UserRole".
        /// </summary>
        public List<MapperUserRoleEntityObject> ObjectsOfUserRoleEntity { get; } =
            new List<MapperUserRoleEntityObject>();

        #endregion Properties
    }
}
