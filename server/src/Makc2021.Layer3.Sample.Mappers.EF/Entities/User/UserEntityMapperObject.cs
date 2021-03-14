// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.User;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserClaim;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserLogin;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserRole;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserToken;

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.User
{
    /// <summary>
    /// Объект сущности "User" для сопоставителя.
    /// </summary>
    public class UserEntityMapperObject : UserEntityObject
    {
        #region Properties

        /// <summary>
        /// Объекты сущности "UserClaim".
        /// </summary>
        public List<UserClaimEntityMapperObject> ObjectsOfUserClaimEntity { get; } =
            new List<UserClaimEntityMapperObject>();

        /// <summary>
        /// Объекты сущности "UserLogin".
        /// </summary>
        public List<UserLoginEntityMapperObject> ObjectsOfUserLoginEntity { get; } =
            new List<UserLoginEntityMapperObject>();

        /// <summary>
        /// Объекты сущности "UserRole".
        /// </summary>
        public List<UserRoleEntityMapperObject> ObjectsOfUserRoleEntity { get; } =
            new List<UserRoleEntityMapperObject>();

        /// <summary>
        /// Объекты сущности "UserToken".
        /// </summary>
        public List<UserTokenEntityMapperObject> ObjectsOfUserTokenEntity { get; } =
            new List<UserTokenEntityMapperObject>();

        #endregion Properties
    }
}
