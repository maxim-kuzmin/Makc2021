// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Загрузчик сущности "DummyTreeLink".
    /// </summary>
    public class DummyTreeLinkEntityLoader : EntityLoader<DummyTreeLinkEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyTreeLinkEntityLoader(DummyTreeLinkEntityObject entityObject = null)
            : base(entityObject ?? new DummyTreeLinkEntityObject())
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

            if (props.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (props.Contains(nameof(EntityObject.ParentId)))
            {
                EntityObject.ParentId = source.ParentId;
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
                nameof(EntityObject.ParentId)
            };
        }

        #endregion Protected methods
    }
}
