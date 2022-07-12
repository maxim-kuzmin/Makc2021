// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.UserLogin
{
    /// <summary>
    /// Загрузчик сущности "UserLogin".
    /// </summary>
    public class UserLoginEntityLoader : EntityLoader<UserLoginEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserLoginEntityLoader(UserLoginEntityObject entityObject = null)
            : base(entityObject ?? new UserLoginEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(UserLoginEntityObject source, HashSet<string> loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(EntityObject.LoginProvider)))
            {
                EntityObject.LoginProvider = source.LoginProvider;
            }

            if (result.Contains(nameof(EntityObject.ProviderDisplayName)))
            {
                EntityObject.ProviderDisplayName = source.ProviderDisplayName;
            }

            if (result.Contains(nameof(EntityObject.ProviderKey)))
            {
                EntityObject.ProviderKey = source.ProviderKey;
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
                nameof(EntityObject.LoginProvider),
                nameof(EntityObject.ProviderDisplayName),
                nameof(EntityObject.ProviderKey),
                nameof(EntityObject.UserId)
            };
        }

        #endregion Protected methods
    }
}
