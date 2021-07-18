// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Схема сущности "DummyMainDummyManyToMany" сопоставителя.
    /// </summary>
    public class MapperDummyMainDummyManyToManyEntitySchema : MapperSchema<MapperDummyMainDummyManyToManyEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperDummyMainDummyManyToManyEntitySchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperDummyMainDummyManyToManyEntityObject> builder)
        {
            Sample.Entities.DummyMainDummyManyToMany.DummyMainDummyManyToManyEntitySetting setting = EntitiesSettings.DummyMainDummyManyToMany;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.IdOfDummyMainEntity, x.IdOfDummyManyToManyEntity }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.IdOfDummyMainEntity)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyMainEntityId);

            builder.Property(x => x.IdOfDummyManyToManyEntity)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyManyToManyEntityId);

            builder.HasIndex(x => x.IdOfDummyManyToManyEntity).HasDatabaseName(setting.DbIndexForDummyManyToManyEntityId);

            builder.HasOne(x => x.ObjectOfDummyMainEntity)
                .WithMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .HasForeignKey(x => x.IdOfDummyMainEntity)
                .HasConstraintName(setting.DbForeignKeyToDummyMainEntity);

            builder.HasOne(x => x.ObjectOfDummyManyToManyEntity)
                .WithMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .HasForeignKey(x => x.IdOfDummyManyToManyEntity)
                .HasConstraintName(setting.DbForeignKeyToDummyManyToManyEntity);
        }

        #endregion Public methods
    }
}
