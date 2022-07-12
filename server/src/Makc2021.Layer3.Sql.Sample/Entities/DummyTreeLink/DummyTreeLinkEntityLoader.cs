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

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(DummyTreeLinkEntityObject source, HashSet<string> loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (result.Contains(nameof(EntityObject.ParentId)))
            {
                EntityObject.ParentId = source.ParentId;
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
                nameof(EntityObject.ParentId)
            };
        }

        #endregion Protected methods
    }
}
