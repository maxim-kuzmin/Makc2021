//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.User
{
    /// <summary>
    /// Сущность "User". Загрузчик.
    /// </summary>
    public class UserEntityLoader : EntityLoader<UserEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public UserEntityLoader(UserEntityObject data = null)
            : base(data ?? new UserEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void LoadDataFrom(UserEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Entity.AccessFailedCount)))
            {
                Entity.AccessFailedCount = source.AccessFailedCount;
            }

            if (props.Contains(nameof(Entity.ConcurrencyStamp)))
            {
                Entity.ConcurrencyStamp = source.ConcurrencyStamp;
            }

            if (props.Contains(nameof(Entity.Email)))
            {
                Entity.Email = source.Email;
            }

            if (props.Contains(nameof(Entity.EmailConfirmed)))
            {
                Entity.EmailConfirmed = source.EmailConfirmed;
            }

            if (props.Contains(nameof(Entity.FullName)))
            {
                Entity.FullName = source.FullName;
            }

            if (props.Contains(nameof(Entity.Id)))
            {
                Entity.Id = source.Id;
            }

            if (props.Contains(nameof(Entity.LockoutEnabled)))
            {
                Entity.LockoutEnabled = source.LockoutEnabled;
            }

            if (props.Contains(nameof(Entity.LockoutEnd)))
            {
                Entity.LockoutEnd = source.LockoutEnd;
            }

            if (props.Contains(nameof(Entity.NormalizedEmail)))
            {
                Entity.NormalizedEmail = source.NormalizedEmail;
            }

            if (props.Contains(nameof(Entity.NormalizedUserName)))
            {
                Entity.NormalizedUserName = source.NormalizedUserName;
            }

            if (props.Contains(nameof(Entity.PasswordHash)))
            {
                Entity.PasswordHash = source.PasswordHash;
            }

            if (props.Contains(nameof(Entity.PhoneNumber)))
            {
                Entity.PhoneNumber = source.PhoneNumber;
            }

            if (props.Contains(nameof(Entity.PhoneNumberConfirmed)))
            {
                Entity.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
            }

            if (props.Contains(nameof(Entity.SecurityStamp)))
            {
                Entity.SecurityStamp = source.SecurityStamp;
            }

            if (props.Contains(nameof(Entity.TwoFactorEnabled)))
            {
                Entity.TwoFactorEnabled = source.TwoFactorEnabled;
            }

            if (props.Contains(nameof(Entity.UserName)))
            {
                Entity.UserName = source.UserName;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать загружаемые свойства данных.
        /// </summary>
        /// <returns>Загружаемые свойства данных.</returns>
        protected override HashSet<string> CreateLoadableEntityProperties()
        {
            return new HashSet<string>
            {
                nameof(Entity.AccessFailedCount),
                nameof(Entity.ConcurrencyStamp),
                nameof(Entity.Email),
                nameof(Entity.EmailConfirmed),
                nameof(Entity.FullName),
                nameof(Entity.Id),
                nameof(Entity.LockoutEnabled),
                nameof(Entity.LockoutEnd),
                nameof(Entity.NormalizedEmail),
                nameof(Entity.NormalizedUserName),
                nameof(Entity.PasswordHash),
                nameof(Entity.PhoneNumber),
                nameof(Entity.PhoneNumberConfirmed),
                nameof(Entity.SecurityStamp),
                nameof(Entity.TwoFactorEnabled),
                nameof(Entity.UserName)
            };
        }

        #endregion Protected methods
    }
}
