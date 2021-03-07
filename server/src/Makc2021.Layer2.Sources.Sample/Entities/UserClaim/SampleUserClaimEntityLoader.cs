//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.Entities.UserClaim
{
    /// <summary>
    /// Источник "Sample". Сущность "UserClaim". Загрузчик.
    /// </summary>
    public class SampleUserClaimEntityLoader : Loader<SampleUserClaimEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public SampleUserClaimEntityLoader(SampleUserClaimEntityObject data = null)
            : base(data ?? new SampleUserClaimEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(SampleUserClaimEntityObject source, HashSet<string> props = null)
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
                nameof(Data.ClaimType),
                nameof(Data.ClaimValue),
                nameof(Data.Id),
                nameof(Data.UserId)
            };
        }

        #endregion Protected methods
    }
}
