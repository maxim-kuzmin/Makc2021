// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.User
{
    /// <summary>
    /// Загрузчик сущности "User".
    /// </summary>
    public class UserEntityLoader : EntityLoader<UserEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserEntityLoader(UserEntityObject entityObject = null)
            : base(entityObject ?? new UserEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void LoadDataFrom(UserEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(EntityObject.AccessFailedCount)))
            {
                EntityObject.AccessFailedCount = source.AccessFailedCount;
            }

            if (props.Contains(nameof(EntityObject.ConcurrencyStamp)))
            {
                EntityObject.ConcurrencyStamp = source.ConcurrencyStamp;
            }

            if (props.Contains(nameof(EntityObject.Email)))
            {
                EntityObject.Email = source.Email;
            }

            if (props.Contains(nameof(EntityObject.EmailConfirmed)))
            {
                EntityObject.EmailConfirmed = source.EmailConfirmed;
            }

            if (props.Contains(nameof(EntityObject.FullName)))
            {
                EntityObject.FullName = source.FullName;
            }

            if (props.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (props.Contains(nameof(EntityObject.LockoutEnabled)))
            {
                EntityObject.LockoutEnabled = source.LockoutEnabled;
            }

            if (props.Contains(nameof(EntityObject.LockoutEnd)))
            {
                EntityObject.LockoutEnd = source.LockoutEnd;
            }

            if (props.Contains(nameof(EntityObject.NormalizedEmail)))
            {
                EntityObject.NormalizedEmail = source.NormalizedEmail;
            }

            if (props.Contains(nameof(EntityObject.NormalizedUserName)))
            {
                EntityObject.NormalizedUserName = source.NormalizedUserName;
            }

            if (props.Contains(nameof(EntityObject.PasswordHash)))
            {
                EntityObject.PasswordHash = source.PasswordHash;
            }

            if (props.Contains(nameof(EntityObject.PhoneNumber)))
            {
                EntityObject.PhoneNumber = source.PhoneNumber;
            }

            if (props.Contains(nameof(EntityObject.PhoneNumberConfirmed)))
            {
                EntityObject.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
            }

            if (props.Contains(nameof(EntityObject.SecurityStamp)))
            {
                EntityObject.SecurityStamp = source.SecurityStamp;
            }

            if (props.Contains(nameof(EntityObject.TwoFactorEnabled)))
            {
                EntityObject.TwoFactorEnabled = source.TwoFactorEnabled;
            }

            if (props.Contains(nameof(EntityObject.UserName)))
            {
                EntityObject.UserName = source.UserName;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать загружаемые свойства данных.
        /// </summary>
        /// <returns>Загружаемые свойства данных.</returns>
        protected override HashSet<string> CreateLoadableProperties()
        {
            return new HashSet<string>
            {
                nameof(EntityObject.AccessFailedCount),
                nameof(EntityObject.ConcurrencyStamp),
                nameof(EntityObject.Email),
                nameof(EntityObject.EmailConfirmed),
                nameof(EntityObject.FullName),
                nameof(EntityObject.Id),
                nameof(EntityObject.LockoutEnabled),
                nameof(EntityObject.LockoutEnd),
                nameof(EntityObject.NormalizedEmail),
                nameof(EntityObject.NormalizedUserName),
                nameof(EntityObject.PasswordHash),
                nameof(EntityObject.PhoneNumber),
                nameof(EntityObject.PhoneNumberConfirmed),
                nameof(EntityObject.SecurityStamp),
                nameof(EntityObject.TwoFactorEnabled),
                nameof(EntityObject.UserName)
            };
        }

        #endregion Protected methods
    }
}
