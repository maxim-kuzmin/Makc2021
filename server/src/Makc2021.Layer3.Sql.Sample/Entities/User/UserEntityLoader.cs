// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.User
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
        public sealed override HashSet<string> Load(UserEntityObject source, HashSet<string> loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(EntityObject.AccessFailedCount)))
            {
                EntityObject.AccessFailedCount = source.AccessFailedCount;
            }

            if (result.Contains(nameof(EntityObject.ConcurrencyStamp)))
            {
                EntityObject.ConcurrencyStamp = source.ConcurrencyStamp;
            }

            if (result.Contains(nameof(EntityObject.Email)))
            {
                EntityObject.Email = source.Email;
            }

            if (result.Contains(nameof(EntityObject.EmailConfirmed)))
            {
                EntityObject.EmailConfirmed = source.EmailConfirmed;
            }

            if (result.Contains(nameof(EntityObject.FullName)))
            {
                EntityObject.FullName = source.FullName;
            }

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (result.Contains(nameof(EntityObject.LockoutEnabled)))
            {
                EntityObject.LockoutEnabled = source.LockoutEnabled;
            }

            if (result.Contains(nameof(EntityObject.LockoutEnd)))
            {
                EntityObject.LockoutEnd = source.LockoutEnd;
            }

            if (result.Contains(nameof(EntityObject.NormalizedEmail)))
            {
                EntityObject.NormalizedEmail = source.NormalizedEmail;
            }

            if (result.Contains(nameof(EntityObject.NormalizedUserName)))
            {
                EntityObject.NormalizedUserName = source.NormalizedUserName;
            }

            if (result.Contains(nameof(EntityObject.PasswordHash)))
            {
                EntityObject.PasswordHash = source.PasswordHash;
            }

            if (result.Contains(nameof(EntityObject.PhoneNumber)))
            {
                EntityObject.PhoneNumber = source.PhoneNumber;
            }

            if (result.Contains(nameof(EntityObject.PhoneNumberConfirmed)))
            {
                EntityObject.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
            }

            if (result.Contains(nameof(EntityObject.SecurityStamp)))
            {
                EntityObject.SecurityStamp = source.SecurityStamp;
            }

            if (result.Contains(nameof(EntityObject.TwoFactorEnabled)))
            {
                EntityObject.TwoFactorEnabled = source.TwoFactorEnabled;
            }

            if (result.Contains(nameof(EntityObject.UserName)))
            {
                EntityObject.UserName = source.UserName;
            }

            return result;
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать загружаемые свойства данных.
        /// </summary>
        /// <returns>Загружаемые свойства данных.</returns>
        protected override HashSet<string> CreateAllPropertiesToLoad()
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
