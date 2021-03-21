// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sample.Entity;

namespace Makc2021.Layer3.Sample.Entities.Role
{
    /// <summary>
    /// Загрузчик сущности "Role".
    /// </summary>
    public class RoleEntityLoader : EntityLoader<RoleEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleEntityLoader(RoleEntityObject entityObject = null)
            : base(entityObject ?? new RoleEntityObject())
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

            if (props.Contains(nameof(EntityObject.ConcurrencyStamp)))
            {
                EntityObject.ConcurrencyStamp = source.ConcurrencyStamp;
            }

            if (props.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = source.Id;
            }

            if (props.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = source.Name;
            }

            if (props.Contains(nameof(EntityObject.NormalizedName)))
            {
                EntityObject.NormalizedName = source.NormalizedName;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableProperties()
        {
            return new HashSet<string>
            {
                nameof(EntityObject.ConcurrencyStamp),
                nameof(EntityObject.Id),
                nameof(EntityObject.Name),
                nameof(EntityObject.NormalizedName)
            };
        }

        #endregion Protected methods
    }
}
