//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2.Sources.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyTreeLink". Загрузчик.
    /// </summary>
    public class SampleDummyTreeLinkEntityLoader : Loader<SampleDummyTreeLinkEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public SampleDummyTreeLinkEntityLoader(SampleDummyTreeLinkEntityObject data = null)
            : base(data ?? new SampleDummyTreeLinkEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(SampleDummyTreeLinkEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.ParentId)))
            {
                Data.ParentId = source.ParentId;
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
                nameof(Data.ParentId)
            };
        }

        #endregion Protected methods
    }
}
