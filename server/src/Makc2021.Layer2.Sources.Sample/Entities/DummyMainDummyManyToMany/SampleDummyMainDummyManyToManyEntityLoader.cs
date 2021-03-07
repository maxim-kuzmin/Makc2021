//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyMainDummyManyToMany". Загрузчик.
    /// </summary>
    public class SampleDummyMainDummyManyToManyEntityLoader : Loader<SampleDummyMainDummyManyToManyEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public SampleDummyMainDummyManyToManyEntityLoader(SampleDummyMainDummyManyToManyEntityObject data = null)
            : base(data ?? new SampleDummyMainDummyManyToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(SampleDummyMainDummyManyToManyEntityObject source, HashSet<string> props = null)
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
