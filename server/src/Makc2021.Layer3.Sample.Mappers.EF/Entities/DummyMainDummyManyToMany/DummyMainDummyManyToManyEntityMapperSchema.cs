// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Схема сущности "DummyMainDummyManyToMany" для сопоставителя.
    /// </summary>
    public class DummyMainDummyManyToManyEntityMapperSchema : MapperSchema<DummyMainDummyManyToManyEntityMapperObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainDummyManyToManyEntityMapperSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DummyMainDummyManyToManyEntityMapperObject> builder)
        {
            Sample.Entities.DummyMainDummyManyToMany.DummyMainDummyManyToManyEntitySetting setting = EntitiesSettings.DummyMainDummyManyToMany;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.ObjectDummyMainId, x.ObjectDummyManyToManyId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ObjectDummyMainId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyMainEntityId);

            builder.Property(x => x.ObjectDummyManyToManyId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyManyToManyEntityId);

            builder.HasIndex(x => x.ObjectDummyManyToManyId).HasDatabaseName(setting.DbIndexForDummyManyToManyEntityId);

            builder.HasOne(x => x.ObjectOfDummyMainEntity)
                .WithMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .HasForeignKey(x => x.ObjectDummyMainId)
                .HasConstraintName(setting.DbForeignKeyToDummyMainEntity);

            builder.HasOne(x => x.ObjectOfDummyManyToManyEntity)
                .WithMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .HasForeignKey(x => x.ObjectDummyManyToManyId)
                .HasConstraintName(setting.DbForeignKeyToDummyManyToManyEntity);
        }

        #endregion Public methods
    }
}
