//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyOneToMany
{
    /// <summary>
    /// Сущность "DummyOneToMany". Загрузчик.
    /// </summary>
    public class DummyOneToManyEntityLoader : EntityLoader<DummyOneToManyEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DummyOneToManyEntityLoader(DummyOneToManyEntityObject data = null)
            : base(data ?? new DummyOneToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DummyOneToManyEntityObject source, HashSet<string> props = null)
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
