// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.UserLogin;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.User;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserLogin
{
    /// <summary>
    /// Объект сущности "UserLogin" для сопоставителя.
    /// </summary>
    public class UserLoginEntityMapperObject : UserLoginEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public UserEntityMapperObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
