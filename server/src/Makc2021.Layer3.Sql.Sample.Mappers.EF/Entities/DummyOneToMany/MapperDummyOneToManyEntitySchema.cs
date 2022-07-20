// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Схема сущности "DummyOneToMany" сопоставителя.
    /// </summary>
    public class MapperDummyOneToManyEntitySchema : MapperSchema<MapperDummyOneToManyEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperDummyOneToManyEntitySchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperDummyOneToManyEntityObject> builder)
        {
            Sample.Entities.DummyOneToMany.DummyOneToManyEntitySettings setting = EntitiesOptions.DummyOneToMany;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(setting.DbMaxLengthForName)
                .HasColumnName(setting.DbColumnForName);

            builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(setting.DbUniqueIndexForName);
        }

        #endregion Public methods    
    }
}
