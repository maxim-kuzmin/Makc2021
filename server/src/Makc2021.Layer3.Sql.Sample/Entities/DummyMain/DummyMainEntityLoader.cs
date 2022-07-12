// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.DummyMain
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

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(DummyMainEntityObject source, HashSet<string> loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (result.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = source.Name ?? string.Empty;
            }

            if (result.Contains(nameof(EntityObject.IdOfDummyOneToManyEntity)))
            {
                EntityObject.IdOfDummyOneToManyEntity = source.IdOfDummyOneToManyEntity;
            }

            if (result.Contains(nameof(EntityObject.PropBoolean)))
            {
                EntityObject.PropBoolean = source.PropBoolean;
            }

            if (result.Contains(nameof(EntityObject.PropBooleanNullable)))
            {
                EntityObject.PropBooleanNullable = source.PropBooleanNullable;
            }

            if (result.Contains(nameof(EntityObject.PropDate)))
            {
                EntityObject.PropDate = source.PropDate;
            }

            if (result.Contains(nameof(EntityObject.PropDateNullable)))
            {
                EntityObject.PropDateNullable = source.PropDateNullable;
            }

            if (result.Contains(nameof(EntityObject.PropDateTimeOffset)))
            {
                EntityObject.PropDateTimeOffset = source.PropDateTimeOffset;
            }

            if (result.Contains(nameof(EntityObject.PropDateTimeOffsetNullable)))
            {
                EntityObject.PropDateTimeOffsetNullable = source.PropDateTimeOffsetNullable;
            }

            if (result.Contains(nameof(EntityObject.PropDecimal)))
            {
                EntityObject.PropDecimal = source.PropDecimal;
            }

            if (result.Contains(nameof(EntityObject.PropDecimalNullable)))
            {
                EntityObject.PropDecimalNullable = source.PropDecimalNullable;
            }

            if (result.Contains(nameof(EntityObject.PropInt32)))
            {
                EntityObject.PropInt32 = source.PropInt32;
            }

            if (result.Contains(nameof(EntityObject.PropInt32Nullable)))
            {
                EntityObject.PropInt32Nullable = source.PropInt32Nullable;
            }

            if (result.Contains(nameof(EntityObject.PropInt64)))
            {
                EntityObject.PropInt64 = source.PropInt64;
            }

            if (result.Contains(nameof(EntityObject.PropInt64Nullable)))
            {
                EntityObject.PropInt64Nullable = source.PropInt64Nullable;
            }

            if (result.Contains(nameof(EntityObject.PropString)))
            {
                EntityObject.PropString = source.PropString ?? string.Empty;
            }

            if (result.Contains(nameof(EntityObject.PropStringNullable)))
            {
                EntityObject.PropStringNullable = source.PropStringNullable;
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
