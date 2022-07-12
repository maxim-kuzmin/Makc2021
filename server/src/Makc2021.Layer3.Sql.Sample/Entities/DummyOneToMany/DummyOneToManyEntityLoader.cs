// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.DummyOneToMany
{
    /// <summary>
    /// Загрузчик сущности "DummyOneToMany".
    /// </summary>
    public class DummyOneToManyEntityLoader : EntityLoader<DummyOneToManyEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyOneToManyEntityLoader(DummyOneToManyEntityObject entityObject = null)
            : base(entityObject ?? new DummyOneToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(DummyOneToManyEntityObject source, HashSet<string> loadableProperties = null)
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
