//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.Entities.DummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyManyToMany". Загрузчик.
    /// </summary>
    public class SampleDummyManyToManyEntityLoader : Loader<SampleDummyManyToManyEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public SampleDummyManyToManyEntityLoader(SampleDummyManyToManyEntityObject data = null)
            : base(data ?? new SampleDummyManyToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(SampleDummyManyToManyEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = source.Name;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.Id),
                nameof(Data.Name)
            };
        }

        #endregion Protected methods
    }
}
