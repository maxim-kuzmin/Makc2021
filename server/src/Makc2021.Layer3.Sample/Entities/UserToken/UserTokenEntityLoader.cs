﻿//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.UserToken
{
    /// <summary>
    /// Сущность "UserToken". Загрузчик.
    /// </summary>
    public class UserTokenEntityLoader : Loader<UserTokenEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public UserTokenEntityLoader(UserTokenEntityObject data = null)
            : base(data ?? new UserTokenEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(UserTokenEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.LoginProvider)))
            {
                Data.LoginProvider = source.LoginProvider;
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = source.Name;
            }

            if (props.Contains(nameof(Data.UserId)))
            {
                Data.UserId = source.UserId;
            }

            if (props.Contains(nameof(Data.Value)))
            {
                Data.Value = source.Value;
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
                nameof(Data.Name),
                nameof(Data.UserId),
                nameof(Data.Value)
            };
        }

        #endregion Protected methods
    }
}
