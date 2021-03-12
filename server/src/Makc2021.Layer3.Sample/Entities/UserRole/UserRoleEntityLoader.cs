// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.UserRole
{
    /// <summary>
    /// Загрузчик сущности "UserRole".
    /// </summary>
    public class UserRoleEntityLoader : EntityLoader<UserRoleEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserRoleEntityLoader(UserRoleEntityObject entityObject = null)
            : base(entityObject ?? new UserRoleEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(UserRoleEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(EntityObject.UserId)))
            {
                EntityObject.UserId = source.UserId;
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
                nameof(EntityObject.UserId),
                nameof(EntityObject.RoleId)
            };
        }

        #endregion Protected methods
    }
}
