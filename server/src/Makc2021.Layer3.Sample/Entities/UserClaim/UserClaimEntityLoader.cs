//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.UserClaim
{
    /// <summary>
    /// Сущность "UserClaim". Загрузчик.
    /// </summary>
    public class UserClaimEntityLoader : EntityLoader<UserClaimEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public UserClaimEntityLoader(UserClaimEntityObject data = null)
            : base(data ?? new UserClaimEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(UserClaimEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Entity.ClaimType)))
            {
                Entity.ClaimType = source.ClaimType;
            }

            if (props.Contains(nameof(Entity.ClaimValue)))
            {
                Entity.ClaimValue = source.ClaimValue;
            }

            if (props.Contains(nameof(Entity.Id)))
            {
                Entity.Id = source.Id;
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
                nameof(Entity.ClaimType),
                nameof(Entity.ClaimValue),
                nameof(Entity.Id),
                nameof(Entity.UserId)
            };
        }

        #endregion Protected methods
    }
}
