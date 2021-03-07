//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.Entities.UserToken
{
    /// <summary>
    /// Источник "Sample". Сущность "UserToken". Загрузчик.
    /// </summary>
    public class SampleUserTokenEntityLoader : Loader<SampleUserTokenEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public SampleUserTokenEntityLoader(SampleUserTokenEntityObject data = null)
            : base(data ?? new SampleUserTokenEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(SampleUserTokenEntityObject source, HashSet<string> props = null)
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
