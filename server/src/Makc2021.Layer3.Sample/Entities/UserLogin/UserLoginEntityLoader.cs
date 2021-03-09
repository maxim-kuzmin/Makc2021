//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.UserLogin
{
    /// <summary>
    /// Сущность "UserLogin". Загрузчик.
    /// </summary>
    public class UserLoginEntityLoader : Loader<UserLoginEntityObject>
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

            if (props.Contains(nameof(Data.LoginProvider)))
            {
                Data.LoginProvider = source.LoginProvider;
            }

            if (props.Contains(nameof(Data.ProviderDisplayName)))
            {
                Data.ProviderDisplayName = source.ProviderDisplayName;
            }

            if (props.Contains(nameof(Data.ProviderKey)))
            {
                Data.ProviderKey = source.ProviderKey;
            }

            if (props.Contains(nameof(Data.UserId)))
            {
                Data.UserId = source.UserId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.LoginProvider),
                nameof(Data.ProviderDisplayName),
                nameof(Data.ProviderKey),
                nameof(Data.UserId)
            };
        }

        #endregion Protected methods
    }
}
