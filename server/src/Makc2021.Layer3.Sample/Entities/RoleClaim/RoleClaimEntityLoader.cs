//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.RoleClaim
{
    /// <summary>
    /// Сущность "RoleClaim". Загрузчик.
    /// </summary>
    public class RoleClaimEntityLoader : Loader<RoleClaimEntityObject>
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

            if (props.Contains(nameof(Data.ClaimType)))
            {
                Data.ClaimType = source.ClaimType;
            }

            if (props.Contains(nameof(Data.ClaimValue)))
            {
                Data.ClaimValue = source.ClaimValue;
            }

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.RoleId)))
            {
                Data.RoleId = source.RoleId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.ClaimType),
                nameof(Data.ClaimValue),
                nameof(Data.Id),
                nameof(Data.RoleId)
            };
        }

        #endregion Protected methods
    }
}
