// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyOneToMany
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

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DummyOneToManyEntityObject source, HashSet<string> props = null)
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
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableProperties()
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
