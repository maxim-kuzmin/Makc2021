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

        /// <inheritdoc/>
        public UserTokenEntityLoader(UserTokenEntityObject entityObject = null)
            : base(entityObject ?? new UserTokenEntityObject())
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

            if (props.Contains(nameof(EntityObject.LoginProvider)))
            {
                EntityObject.LoginProvider = source.LoginProvider;
            }

            if (props.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = source.Name;
            }

            if (props.Contains(nameof(EntityObject.UserId)))
            {
                EntityObject.UserId = source.UserId;
            }

            if (props.Contains(nameof(EntityObject.Value)))
            {
                EntityObject.Value = source.Value;
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
                nameof(EntityObject.Name),
                nameof(EntityObject.UserId),
                nameof(EntityObject.Value)
            };
        }

        #endregion Protected methods
    }
}
