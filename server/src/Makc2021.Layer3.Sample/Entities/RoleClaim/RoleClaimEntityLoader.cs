//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.RoleClaim
{
    /// <summary>
    /// Сущность "RoleClaim". Загрузчик.
    /// </summary>
    public class RoleClaimEntityLoader : EntityLoader<RoleClaimEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public RoleClaimEntityLoader(RoleClaimEntityObject data = null)
            : base(data ?? new RoleClaimEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(RoleClaimEntityObject source, HashSet<string> props = null)
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

            if (props.Contains(nameof(Entity.RoleId)))
            {
                Entity.RoleId = source.RoleId;
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
                nameof(Entity.RoleId)
            };
        }

        #endregion Protected methods
    }
}
