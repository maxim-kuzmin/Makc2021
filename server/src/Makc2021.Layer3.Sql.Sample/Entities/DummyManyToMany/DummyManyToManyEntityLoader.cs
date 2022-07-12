// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.DummyManyToMany
{
    /// <summary>
    /// Загрузчик сущности "DummyManyToMany".
    /// </summary>
    public class DummyManyToManyEntityLoader : EntityLoader<DummyManyToManyEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyManyToManyEntityLoader(DummyManyToManyEntityObject entityObject = null)
            : base(entityObject ?? new DummyManyToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(DummyManyToManyEntityObject source, HashSet<string> loadableProperties = null)
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
                nameof(EntityObject.Name)
            };
        }

        #endregion Protected methods
    }
}
