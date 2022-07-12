// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.DummyTree
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

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(DummyTreeEntityObject source, HashSet<string> loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (result.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = source.Name;
            }

            if (result.Contains(nameof(EntityObject.ParentId)))
            {
                EntityObject.ParentId = source.ParentId;
            }

            if (result.Contains(nameof(EntityObject.TreeChildCount)))
            {
                EntityObject.TreeChildCount = source.TreeChildCount;
            }

            if (result.Contains(nameof(EntityObject.TreeDescendantCount)))
            {
                EntityObject.TreeDescendantCount = source.TreeDescendantCount;
            }

            if (result.Contains(nameof(EntityObject.TreeLevel)))
            {
                EntityObject.TreeLevel = source.TreeLevel;
            }

            if (result.Contains(nameof(EntityObject.TreePath)))
            {
                EntityObject.TreePath = source.TreePath;
            }

            if (result.Contains(nameof(EntityObject.TreePosition)))
            {
                EntityObject.TreePosition = source.TreePosition;
            }

            if (result.Contains(nameof(EntityObject.TreeSort)))
            {
                EntityObject.TreeSort = source.TreeSort;
            }

            return result;
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateAllPropertiesToLoad()
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
