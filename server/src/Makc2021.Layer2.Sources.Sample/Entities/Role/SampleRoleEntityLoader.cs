//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.Entities.Role
{
    /// <summary>
    /// Источник "Sample". Сущность "Role". Загрузчик.
    /// </summary>
    public class SampleRoleEntityLoader : Loader<SampleRoleEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public SampleRoleEntityLoader(SampleRoleEntityObject data = null)
            : base(data ?? new SampleRoleEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(SampleRoleEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.ConcurrencyStamp)))
            {
                Data.ConcurrencyStamp = source.ConcurrencyStamp;
            }

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = source.Name;
            }

            if (props.Contains(nameof(Data.NormalizedName)))
            {
                Data.NormalizedName = source.NormalizedName;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.ConcurrencyStamp),
                nameof(Data.Id),
                nameof(Data.Name),
                nameof(Data.NormalizedName)
            };
        }

        #endregion Protected methods
    }
}
