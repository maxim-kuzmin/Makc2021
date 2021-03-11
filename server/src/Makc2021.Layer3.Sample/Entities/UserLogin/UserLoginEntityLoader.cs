//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.UserLogin
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

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(UserLoginEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(EntityObject.LoginProvider)))
            {
                EntityObject.LoginProvider = source.LoginProvider;
            }

            if (props.Contains(nameof(EntityObject.ProviderDisplayName)))
            {
                EntityObject.ProviderDisplayName = source.ProviderDisplayName;
            }

            if (props.Contains(nameof(EntityObject.ProviderKey)))
            {
                EntityObject.ProviderKey = source.ProviderKey;
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
                nameof(EntityObject.LoginProvider),
                nameof(EntityObject.ProviderDisplayName),
                nameof(EntityObject.ProviderKey),
                nameof(EntityObject.UserId)
            };
        }

        #endregion Protected methods
    }
}
