// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.UserToken
{
    /// <summary>
    /// Загрузчик сущности "UserToken".
    /// </summary>
    public class UserTokenEntityLoader : EntityLoader<UserTokenEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserTokenEntityLoader(UserTokenEntityObject entityObject = null)
            : base(entityObject ?? new UserTokenEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(UserTokenEntityObject source, HashSet<string> loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(EntityObject.LoginProvider)))
            {
                EntityObject.LoginProvider = source.LoginProvider;
            }

            if (result.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = source.Name;
            }

            if (result.Contains(nameof(EntityObject.UserId)))
            {
                EntityObject.UserId = source.UserId;
            }

            if (result.Contains(nameof(EntityObject.Value)))
            {
                EntityObject.Value = source.Value;
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
                nameof(EntityObject.Name),
                nameof(EntityObject.UserId),
                nameof(EntityObject.Value)
            };
        }

        #endregion Protected methods
    }
}
