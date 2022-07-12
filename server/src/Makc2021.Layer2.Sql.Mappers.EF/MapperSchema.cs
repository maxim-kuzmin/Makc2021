// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sql.Mappers.EF
{
    /// <summary>
    /// Схема сопоставителя.
    /// </summary>
    /// <typeparam name="TEntitiesSettings">Тип настроек сущностей.</typeparam>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class MapperSchema<TEntitiesSettings, TEntityObject> : IEntityTypeConfiguration<TEntityObject>
        where TEntityObject : class
    {
        #region Properties

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        protected TEntitiesSettings EntitiesSettings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="entitiesSettings">Настройки сущностей.</param>
        public MapperSchema(TEntitiesSettings entitiesSettings)
        {
            EntitiesSettings = entitiesSettings;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public abstract void Configure(EntityTypeBuilder<TEntityObject> builder);

        #endregion Public methods
    }
}
