// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.UserLogin;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.User;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserLogin
{
    /// <summary>
    /// Объект сущности "UserLogin" сопоставителя.
    /// </summary>
    public class MapperUserLoginEntityObject : UserLoginEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public MapperUserEntityObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
