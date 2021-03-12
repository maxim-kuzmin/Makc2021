// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.Role;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.RoleClaim;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserRole;
using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.Role
{
    /// <summary>
    /// Объект ORM сущности "Role".
    /// </summary>
    public class RoleEntityMapperObject : RoleEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "RoleClaim".
        /// </summary>
        public List<RoleClaimEntityMapperObject> ObjectsOfRoleClaimEntity { get; } =
            new List<RoleClaimEntityMapperObject>();

        /// <summary>
        /// Объекты сущности "UserRole".
        /// </summary>
        public List<UserRoleEntityMapperObject> ObjectsOfUserRoleEntity { get; } =
            new List<UserRoleEntityMapperObject>();

        #endregion Properties
    }
}
