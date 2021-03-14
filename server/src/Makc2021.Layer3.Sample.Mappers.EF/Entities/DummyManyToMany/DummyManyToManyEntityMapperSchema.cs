// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Схема сущности "DummyManyToMany" для сопоставителя.
    /// </summary>
    public class DummyManyToManyEntityMapperSchema : MapperSchema<DummyManyToManyEntityMapperObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyManyToManyEntityMapperSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DummyManyToManyEntityMapperObject> builder)
        {
            Sample.Entities.DummyManyToMany.DummyManyToManyEntitySetting setting = EntitiesSettings.DummyManyToMany;

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
