// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities.UserClaim;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim
{
    /// <summary>
    /// Объект сущности "UserClaim" сопоставителя.
    /// </summary>
    public class MapperUserClaimEntityObject : UserClaimEntityObject
    {
        #region Properties

        /// <summary>
        /// Объект сущности "User".
        /// </summary>
        public MapperUserEntityObject ObjectOfUserEntity { get; set; }

        #endregion Properties
    }
}
