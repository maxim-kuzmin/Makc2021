//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.Role
{
    /// <summary>
    /// Сущность "Role". Загрузчик.
    /// </summary>
    public class RoleEntityLoader : Loader<RoleEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public RoleEntityLoader(RoleEntityObject data = null)
            : base(data ?? new RoleEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(RoleEntityObject source, HashSet<string> props = null)
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
