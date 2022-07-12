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

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(RoleClaimEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(EntityObject.ClaimType)))
            {
                EntityObject.ClaimType = source.ClaimType;
            }

            if (props.Contains(nameof(EntityObject.ClaimValue)))
            {
                EntityObject.ClaimValue = source.ClaimValue;
            }

            if (props.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (props.Contains(nameof(EntityObject.RoleId)))
            {
                EntityObject.RoleId = source.RoleId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableProperties()
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
