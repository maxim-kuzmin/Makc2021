//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.UserLogin
{
    /// <summary>
    /// Сущность "UserLogin". Загрузчик.
    /// </summary>
    public class UserLoginEntityLoader : EntityLoader<UserLoginEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public UserLoginEntityLoader(UserLoginEntityObject data = null)
            : base(data ?? new UserLoginEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(UserLoginEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Entity.LoginProvider)))
            {
                Entity.LoginProvider = source.LoginProvider;
            }

            if (props.Contains(nameof(Entity.ProviderDisplayName)))
            {
                Entity.ProviderDisplayName = source.ProviderDisplayName;
            }

            if (props.Contains(nameof(Entity.ProviderKey)))
            {
                Entity.ProviderKey = source.ProviderKey;
            }

            if (props.Contains(nameof(Entity.UserId)))
            {
                Entity.UserId = source.UserId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableEntityProperties()
        {
            return new HashSet<string>
            {
                nameof(Entity.LoginProvider),
                nameof(Entity.ProviderDisplayName),
                nameof(Entity.ProviderKey),
                nameof(Entity.UserId)
            };
        }

        #endregion Protected methods
    }
}
