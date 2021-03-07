//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.Entities.UserRole
{
    /// <summary>
    /// Источник "Sample". Сущность "UserRole". Загрузчик.
    /// </summary>
    public class SampleUserRoleEntityLoader : Loader<SampleUserRoleEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public SampleUserRoleEntityLoader(SampleUserRoleEntityObject data = null)
            : base(data ?? new SampleUserRoleEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(SampleUserRoleEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.UserId)))
            {
                Data.UserId = source.UserId;
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
                nameof(Data.UserId),
                nameof(Data.RoleId)
            };
        }

        #endregion Protected methods
    }
}
