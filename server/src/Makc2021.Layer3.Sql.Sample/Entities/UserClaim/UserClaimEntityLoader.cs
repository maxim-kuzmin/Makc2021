// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.UserClaim
{
    /// <summary>
    /// Загрузчик сущности "UserClaim".
    /// </summary>
    public class UserClaimEntityLoader : EntityLoader<UserClaimEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserClaimEntityLoader(UserClaimEntityObject entityObject = null)
            : base(entityObject ?? new UserClaimEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(UserClaimEntityObject source, HashSet<string> loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(EntityObject.ClaimType)))
            {
                EntityObject.ClaimType = source.ClaimType;
            }

            if (result.Contains(nameof(EntityObject.ClaimValue)))
            {
                EntityObject.ClaimValue = source.ClaimValue;
            }

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (result.Contains(nameof(EntityObject.UserId)))
            {
                EntityObject.UserId = source.UserId;
            }

            return result;
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateAllPropertiesToLoad()
        {
            return new HashSet<string>
            {
                nameof(EntityObject.ClaimType),
                nameof(EntityObject.ClaimValue),
                nameof(EntityObject.Id),
                nameof(EntityObject.UserId)
            };
        }

        #endregion Protected methods
    }
}
