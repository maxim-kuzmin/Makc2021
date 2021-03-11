﻿//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.UserClaim;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.User;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserClaim
{
    /// <summary>
    /// Объект ORM сущности "UserClaim".
    /// </summary>
    public class UserClaimEntityMapperObject : UserClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public UserEntityMapperObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
