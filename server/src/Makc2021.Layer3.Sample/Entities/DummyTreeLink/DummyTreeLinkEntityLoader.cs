//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Сущность "DummyTreeLink". Загрузчик.
    /// </summary>
    public class DummyTreeLinkEntityLoader : EntityLoader<DummyTreeLinkEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DummyTreeLinkEntityLoader(DummyTreeLinkEntityObject data = null)
            : base(data ?? new DummyTreeLinkEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DummyTreeLinkEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Entity.Id)))
            {
                Entity.Id = source.Id;
            }

            if (props.Contains(nameof(Entity.ParentId)))
            {
                Entity.ParentId = source.ParentId;
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
                nameof(Entity.ParentId)
            };
        }

        #endregion Protected methods
    }
}
