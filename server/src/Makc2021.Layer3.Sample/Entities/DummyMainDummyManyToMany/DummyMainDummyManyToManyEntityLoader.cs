// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sample.Entity;

namespace Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Загрузчик сущности "DummyMainDummyManyToMany".
    /// </summary>
    public class DummyMainDummyManyToManyEntityLoader : EntityLoader<DummyMainDummyManyToManyEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainDummyManyToManyEntityLoader(DummyMainDummyManyToManyEntityObject entityObject = null)
            : base(entityObject ?? new DummyMainDummyManyToManyEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DummyMainDummyManyToManyEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(EntityObject.IdOfDummyMainEntity)))
            {
                EntityObject.IdOfDummyMainEntity = source.IdOfDummyMainEntity;
            }

            if (props.Contains(nameof(EntityObject.IdOfDummyManyToManyEntity)))
            {
                EntityObject.IdOfDummyManyToManyEntity = source.IdOfDummyManyToManyEntity;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableProperties()
        {
            return new HashSet<string>
            {
                nameof(EntityObject.IdOfDummyMainEntity),
                nameof(EntityObject.IdOfDummyManyToManyEntity)
            };
        }

        #endregion Protected methods
    }
}
