//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность "DummyMainDummyManyToMany". Загрузчик.
    /// </summary>
    public class DummyMainDummyManyToManyEntityLoader : EntityLoader<DummyMainDummyManyToManyEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainDummyManyToManyEntityLoader(DummyMainDummyManyToManyEntityObject entityObject = null)
            : base(entityObject ?? new DummyMainDummyManyToManyEntityObject())
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

            if (props.Contains(nameof(EntityObject.ObjectDummyMainId)))
            {
                EntityObject.ObjectDummyMainId = source.ObjectDummyMainId;
            }

            if (props.Contains(nameof(EntityObject.ObjectDummyManyToManyId)))
            {
                EntityObject.ObjectDummyManyToManyId = source.ObjectDummyManyToManyId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableProperties()
        {
            return new HashSet<string>
            {
                nameof(EntityObject.ObjectDummyMainId),
                nameof(EntityObject.ObjectDummyManyToManyId)
            };
        }

        #endregion Protected methods
    }
}
