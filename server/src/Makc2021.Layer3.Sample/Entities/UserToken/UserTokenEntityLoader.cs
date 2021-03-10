//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.UserToken
{
    /// <summary>
    /// Сущность "UserToken". Загрузчик.
    /// </summary>
    public class UserTokenEntityLoader : EntityLoader<UserTokenEntityObject>
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

            if (props.Contains(nameof(Entity.LoginProvider)))
            {
                Entity.LoginProvider = source.LoginProvider;
            }

            if (props.Contains(nameof(Entity.Name)))
            {
                Entity.Name = source.Name;
            }

            if (props.Contains(nameof(Entity.UserId)))
            {
                Entity.UserId = source.UserId;
            }

            if (props.Contains(nameof(Entity.Value)))
            {
                Entity.Value = source.Value;
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
                nameof(Entity.Name),
                nameof(Entity.UserId),
                nameof(Entity.Value)
            };
        }

        #endregion Protected methods
    }
}
