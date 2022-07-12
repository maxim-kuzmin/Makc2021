// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.RoleClaim
{
    /// <summary>
    /// Загрузчик сущности "RoleClaim".
    /// </summary>
    public class RoleClaimEntityLoader : EntityLoader<RoleClaimEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleClaimEntityLoader(RoleClaimEntityObject entityObject = null)
            : base(entityObject ?? new RoleClaimEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(RoleClaimEntityObject source, HashSet<string> loadableProperties = null)
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

            if (result.Contains(nameof(EntityObject.RoleId)))
            {
                EntityObject.RoleId = source.RoleId;
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
                nameof(EntityObject.RoleId)
            };
        }

        #endregion Protected methods
    }
}
