//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyTree
{
    /// <summary>
    /// Сущность "DummyTree". Загрузчик.
    /// </summary>
    public class DummyTreeEntityLoader : EntityLoader<DummyTreeEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DummyTreeEntityLoader(DummyTreeEntityObject data = null)
            : base(data ?? new DummyTreeEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DummyTreeEntityObject source, HashSet<string> props = null)
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

            if (props.Contains(nameof(Entity.ParentId)))
            {
                Entity.ParentId = source.ParentId;
            }

            if (props.Contains(nameof(Entity.TreeChildCount)))
            {
                Entity.TreeChildCount = source.TreeChildCount;
            }

            if (props.Contains(nameof(Entity.TreeDescendantCount)))
            {
                Entity.TreeDescendantCount = source.TreeDescendantCount;
            }

            if (props.Contains(nameof(Entity.TreeLevel)))
            {
                Entity.TreeLevel = source.TreeLevel;
            }

            if (props.Contains(nameof(Entity.TreePath)))
            {
                Entity.TreePath = source.TreePath;
            }

            if (props.Contains(nameof(Entity.TreePosition)))
            {
                Entity.TreePosition = source.TreePosition;
            }

            if (props.Contains(nameof(Entity.TreeSort)))
            {
                Entity.TreeSort = source.TreeSort;
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
                nameof(Entity.Name),
                nameof(Entity.ParentId),
                nameof(Entity.TreeChildCount),
                nameof(Entity.TreeDescendantCount),
                nameof(Entity.TreeLevel),
                nameof(Entity.TreePath),
                nameof(Entity.TreeSort)
            };
        }

        #endregion Protected methods
    }
}
