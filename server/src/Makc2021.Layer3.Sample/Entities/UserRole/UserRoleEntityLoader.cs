﻿//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.UserRole
{
    /// <summary>
    /// Сущность "UserRole". Загрузчик.
    /// </summary>
    public class UserRoleEntityLoader : EntityLoader<UserRoleEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public UserRoleEntityLoader(UserRoleEntityObject data = null)
            : base(data ?? new UserRoleEntityObject())
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

            if (props.Contains(nameof(Entity.UserId)))
            {
                Entity.UserId = source.UserId;
            }

            if (props.Contains(nameof(Entity.RoleId)))
            {
                Entity.RoleId = source.RoleId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableEntityProperties()
        {
            return new HashSet<string>
            {
                nameof(Entity.UserId),
                nameof(Entity.RoleId)
            };
        }

        #endregion Protected methods
    }
}
