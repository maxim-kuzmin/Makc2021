// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.UserClaim
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

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(UserClaimEntityObject source, HashSet<string> props = null)
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

            if (props.Contains(nameof(EntityObject.UserId)))
            {
                EntityObject.UserId = source.UserId;
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
                nameof(EntityObject.UserId)
            };
        }

        #endregion Protected methods
    }
}
