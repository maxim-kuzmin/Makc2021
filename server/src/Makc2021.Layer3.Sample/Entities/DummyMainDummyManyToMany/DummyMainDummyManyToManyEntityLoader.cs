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

            if (props.Contains(nameof(Entity.ObjectDummyMainId)))
            {
                Entity.ObjectDummyMainId = source.ObjectDummyMainId;
            }

            if (props.Contains(nameof(Entity.ObjectDummyManyToManyId)))
            {
                Entity.ObjectDummyManyToManyId = source.ObjectDummyManyToManyId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableEntityProperties()
        {
            return new HashSet<string>
            {
                nameof(Entity.ObjectDummyMainId),
                nameof(Entity.ObjectDummyManyToManyId)
            };
        }

        #endregion Protected methods
    }
}
