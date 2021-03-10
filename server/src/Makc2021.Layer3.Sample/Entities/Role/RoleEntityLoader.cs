﻿//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer3.Sample.Entities.Role
{
    /// <summary>
    /// Сущность "Role". Загрузчик.
    /// </summary>
    public class RoleEntityLoader : EntityLoader<RoleEntityObject>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public RoleEntityLoader(RoleEntityObject data = null)
            : base(data ?? new RoleEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(RoleEntityObject source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Entity.ConcurrencyStamp)))
            {
                Entity.ConcurrencyStamp = source.ConcurrencyStamp;
            }

            if (props.Contains(nameof(Entity.Id)))
            {
                Entity.Id = source.Id;
            }

            if (props.Contains(nameof(Entity.Name)))
            {
                Entity.Name = source.Name;
            }

            if (props.Contains(nameof(Entity.NormalizedName)))
            {
                Entity.NormalizedName = source.NormalizedName;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableEntityProperties()
        {
            return new HashSet<string>
            {
                nameof(Entity.ConcurrencyStamp),
                nameof(Entity.Id),
                nameof(Entity.Name),
                nameof(Entity.NormalizedName)
            };
        }

        #endregion Protected methods
    }
}
