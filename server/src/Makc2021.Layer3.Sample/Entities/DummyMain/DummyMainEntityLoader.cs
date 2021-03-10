//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.DummyMain
{
    /// <summary>
    /// Сущность "DummyMain". Загрузчик.
    /// </summary>
    public class DummyMainEntityLoader : EntityLoader<DummyMainEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DummyMainEntityLoader(DummyMainEntityObject data = null)
                : base(data ?? new DummyMainEntityObject())
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

            if (props.Contains(nameof(Entity.Id)))
            {
                Entity.Id = source.Id;
            }

            if (props.Contains(nameof(Entity.Name)))
            {
                Entity.Name = source.Name ?? string.Empty;
            }

            if (props.Contains(nameof(Entity.ObjectDummyOneToManyId)))
            {
                Entity.ObjectDummyOneToManyId = source.ObjectDummyOneToManyId;
            }

            if (props.Contains(nameof(Entity.PropBoolean)))
            {
                Entity.PropBoolean = source.PropBoolean;
            }

            if (props.Contains(nameof(Entity.PropBooleanNullable)))
            {
                Entity.PropBooleanNullable = source.PropBooleanNullable;
            }

            if (props.Contains(nameof(Entity.PropDate)))
            {
                Entity.PropDate = source.PropDate;
            }

            if (props.Contains(nameof(Entity.PropDateNullable)))
            {
                Entity.PropDateNullable = source.PropDateNullable;
            }

            if (props.Contains(nameof(Entity.PropDateTimeOffset)))
            {
                Entity.PropDateTimeOffset = source.PropDateTimeOffset;
            }

            if (props.Contains(nameof(Entity.PropDateTimeOffsetNullable)))
            {
                Entity.PropDateTimeOffsetNullable = source.PropDateTimeOffsetNullable;
            }

            if (props.Contains(nameof(Entity.PropDecimal)))
            {
                Entity.PropDecimal = source.PropDecimal;
            }

            if (props.Contains(nameof(Entity.PropDecimalNullable)))
            {
                Entity.PropDecimalNullable = source.PropDecimalNullable;
            }

            if (props.Contains(nameof(Entity.PropInt32)))
            {
                Entity.PropInt32 = source.PropInt32;
            }

            if (props.Contains(nameof(Entity.PropInt32Nullable)))
            {
                Entity.PropInt32Nullable = source.PropInt32Nullable;
            }

            if (props.Contains(nameof(Entity.PropInt64)))
            {
                Entity.PropInt64 = source.PropInt64;
            }

            if (props.Contains(nameof(Entity.PropInt64Nullable)))
            {
                Entity.PropInt64Nullable = source.PropInt64Nullable;
            }

            if (props.Contains(nameof(Entity.PropString)))
            {
                Entity.PropString = source.PropString ?? string.Empty;
            }

            if (props.Contains(nameof(Entity.PropStringNullable)))
            {
                Entity.PropStringNullable = source.PropStringNullable;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableEntityProperties()
        {
            return new HashSet<string>
            {
                nameof(Entity.Id),
                nameof(Entity.Name),
                nameof(Entity.ObjectDummyOneToManyId),
                nameof(Entity.PropBoolean),
                nameof(Entity.PropBooleanNullable),
                nameof(Entity.PropDate),
                nameof(Entity.PropDateNullable),
                nameof(Entity.PropDateTimeOffset),
                nameof(Entity.PropDateTimeOffsetNullable),
                nameof(Entity.PropDecimal),
                nameof(Entity.PropDecimalNullable),
                nameof(Entity.PropInt32),
                nameof(Entity.PropInt32Nullable),
                nameof(Entity.PropInt64),
                nameof(Entity.PropInt64Nullable),
                nameof(Entity.PropString),
                nameof(Entity.PropStringNullable)
            };
        }

        #endregion Protected methods
    }
}
