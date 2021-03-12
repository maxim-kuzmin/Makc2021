// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyTree
{
    /// <summary>
    /// Загрузчик сущности "DummyTree".
    /// </summary>
    public class DummyTreeEntityLoader : EntityLoader<DummyTreeEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyTreeEntityLoader(DummyTreeEntityObject entityObject = null)
            : base(entityObject ?? new DummyTreeEntityObject())
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

            if (props.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (props.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = source.Name;
            }

            if (props.Contains(nameof(EntityObject.ParentId)))
            {
                EntityObject.ParentId = source.ParentId;
            }

            if (props.Contains(nameof(EntityObject.TreeChildCount)))
            {
                EntityObject.TreeChildCount = source.TreeChildCount;
            }

            if (props.Contains(nameof(EntityObject.TreeDescendantCount)))
            {
                EntityObject.TreeDescendantCount = source.TreeDescendantCount;
            }

            if (props.Contains(nameof(EntityObject.TreeLevel)))
            {
                EntityObject.TreeLevel = source.TreeLevel;
            }

            if (props.Contains(nameof(EntityObject.TreePath)))
            {
                EntityObject.TreePath = source.TreePath;
            }

            if (props.Contains(nameof(EntityObject.TreePosition)))
            {
                EntityObject.TreePosition = source.TreePosition;
            }

            if (props.Contains(nameof(EntityObject.TreeSort)))
            {
                EntityObject.TreeSort = source.TreeSort;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableProperties()
        {
            return new HashSet<string>
            {
                nameof(EntityObject.Id),
                nameof(EntityObject.Name),
                nameof(EntityObject.ParentId),
                nameof(EntityObject.TreeChildCount),
                nameof(EntityObject.TreeDescendantCount),
                nameof(EntityObject.TreeLevel),
                nameof(EntityObject.TreePath),
                nameof(EntityObject.TreeSort)
            };
        }

        #endregion Protected methods
    }
}
