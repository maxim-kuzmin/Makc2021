﻿//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyTree
{
    /// <summary>
    /// Сущность "DummyTree". Загрузчик.
    /// </summary>
    public class DummyTreeEntityLoader : Loader<DummyTreeEntityObject>
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

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = source.Name;
            }

            if (props.Contains(nameof(Data.ParentId)))
            {
                Data.ParentId = source.ParentId;
            }

            if (props.Contains(nameof(Data.TreeChildCount)))
            {
                Data.TreeChildCount = source.TreeChildCount;
            }

            if (props.Contains(nameof(Data.TreeDescendantCount)))
            {
                Data.TreeDescendantCount = source.TreeDescendantCount;
            }

            if (props.Contains(nameof(Data.TreeLevel)))
            {
                Data.TreeLevel = source.TreeLevel;
            }

            if (props.Contains(nameof(Data.TreePath)))
            {
                Data.TreePath = source.TreePath;
            }

            if (props.Contains(nameof(Data.TreePosition)))
            {
                Data.TreePosition = source.TreePosition;
            }

            if (props.Contains(nameof(Data.TreeSort)))
            {
                Data.TreeSort = source.TreeSort;
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
                nameof(Data.Name),
                nameof(Data.ParentId),
                nameof(Data.TreeChildCount),
                nameof(Data.TreeDescendantCount),
                nameof(Data.TreeLevel),
                nameof(Data.TreePath),
                nameof(Data.TreeSort)
            };
        }

        #endregion Protected methods
    }
}
