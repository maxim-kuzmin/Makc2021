//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность "DummyMainDummyManyToMany". Загрузчик.
    /// </summary>
    public class DummyMainDummyManyToManyEntityLoader : Loader<DummyMainDummyManyToManyEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DummyMainDummyManyToManyEntityLoader(DummyMainDummyManyToManyEntityObject data = null)
            : base(data ?? new DummyMainDummyManyToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DummyMainDummyManyToManyEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.ObjectDummyMainId)))
            {
                Data.ObjectDummyMainId = source.ObjectDummyMainId;
            }

            if (props.Contains(nameof(Data.ObjectDummyManyToManyId)))
            {
                Data.ObjectDummyManyToManyId = source.ObjectDummyManyToManyId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.ObjectDummyMainId),
                nameof(Data.ObjectDummyManyToManyId)
            };
        }

        #endregion Protected methods
    }
}
