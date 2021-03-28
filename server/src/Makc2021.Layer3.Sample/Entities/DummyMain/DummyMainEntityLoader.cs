// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer2.Entity;

namespace Makc2021.Layer3.Sample.Entities.DummyMain
{
    /// <summary>
    /// Загрузчик сущности "DummyMain".
    /// </summary>
    public class DummyMainEntityLoader : EntityLoader<DummyMainEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainEntityLoader(DummyMainEntityObject entityObject = null)
                : base(entityObject ?? new DummyMainEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DummyMainEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (props.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = source.Name ?? string.Empty;
            }

            if (props.Contains(nameof(EntityObject.IdOfDummyOneToManyEntity)))
            {
                EntityObject.IdOfDummyOneToManyEntity = source.IdOfDummyOneToManyEntity;
            }

            if (props.Contains(nameof(EntityObject.PropBoolean)))
            {
                EntityObject.PropBoolean = source.PropBoolean;
            }

            if (props.Contains(nameof(EntityObject.PropBooleanNullable)))
            {
                EntityObject.PropBooleanNullable = source.PropBooleanNullable;
            }

            if (props.Contains(nameof(EntityObject.PropDate)))
            {
                EntityObject.PropDate = source.PropDate;
            }

            if (props.Contains(nameof(EntityObject.PropDateNullable)))
            {
                EntityObject.PropDateNullable = source.PropDateNullable;
            }

            if (props.Contains(nameof(EntityObject.PropDateTimeOffset)))
            {
                EntityObject.PropDateTimeOffset = source.PropDateTimeOffset;
            }

            if (props.Contains(nameof(EntityObject.PropDateTimeOffsetNullable)))
            {
                EntityObject.PropDateTimeOffsetNullable = source.PropDateTimeOffsetNullable;
            }

            if (props.Contains(nameof(EntityObject.PropDecimal)))
            {
                EntityObject.PropDecimal = source.PropDecimal;
            }

            if (props.Contains(nameof(EntityObject.PropDecimalNullable)))
            {
                EntityObject.PropDecimalNullable = source.PropDecimalNullable;
            }

            if (props.Contains(nameof(EntityObject.PropInt32)))
            {
                EntityObject.PropInt32 = source.PropInt32;
            }

            if (props.Contains(nameof(EntityObject.PropInt32Nullable)))
            {
                EntityObject.PropInt32Nullable = source.PropInt32Nullable;
            }

            if (props.Contains(nameof(EntityObject.PropInt64)))
            {
                EntityObject.PropInt64 = source.PropInt64;
            }

            if (props.Contains(nameof(EntityObject.PropInt64Nullable)))
            {
                EntityObject.PropInt64Nullable = source.PropInt64Nullable;
            }

            if (props.Contains(nameof(EntityObject.PropString)))
            {
                EntityObject.PropString = source.PropString ?? string.Empty;
            }

            if (props.Contains(nameof(EntityObject.PropStringNullable)))
            {
                EntityObject.PropStringNullable = source.PropStringNullable;
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
                nameof(EntityObject.IdOfDummyOneToManyEntity),
                nameof(EntityObject.PropBoolean),
                nameof(EntityObject.PropBooleanNullable),
                nameof(EntityObject.PropDate),
                nameof(EntityObject.PropDateNullable),
                nameof(EntityObject.PropDateTimeOffset),
                nameof(EntityObject.PropDateTimeOffsetNullable),
                nameof(EntityObject.PropDecimal),
                nameof(EntityObject.PropDecimalNullable),
                nameof(EntityObject.PropInt32),
                nameof(EntityObject.PropInt32Nullable),
                nameof(EntityObject.PropInt64),
                nameof(EntityObject.PropInt64Nullable),
                nameof(EntityObject.PropString),
                nameof(EntityObject.PropStringNullable)
            };
        }

        #endregion Protected methods
    }
}
