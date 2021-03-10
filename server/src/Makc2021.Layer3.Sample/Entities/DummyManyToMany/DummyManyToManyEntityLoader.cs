//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyManyToMany
{
    /// <summary>
    /// Сущность "DummyManyToMany". Загрузчик.
    /// </summary>
    public class DummyManyToManyEntityLoader : EntityLoader<DummyManyToManyEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DummyManyToManyEntityLoader(DummyManyToManyEntityObject data = null)
            : base(data ?? new DummyManyToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DummyManyToManyEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Entity.Id)))
            {
                Entity.Id = source.Id;
            }

            if (props.Contains(nameof(Entity.Name)))
            {
                Entity.Name = source.Name;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableEntityProperties()
        {
            return new HashSet<string>
            {
                nameof(Entity.Id),
                nameof(Entity.Name)
            };
        }

        #endregion Protected methods
    }
}
