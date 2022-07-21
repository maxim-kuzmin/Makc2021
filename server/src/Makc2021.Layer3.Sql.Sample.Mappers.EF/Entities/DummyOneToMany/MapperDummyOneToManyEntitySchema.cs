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
        public MapperDummyOneToManyEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperDummyOneToManyEntityObject> builder)
        {
            var options = EntitiesOptions.DummyOneToMany;

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => x.Id).HasName(options.DbPrimaryKey);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(options.DbColumnForId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(options.DbMaxLengthForName)
                .HasColumnName(options.DbColumnForName);

            builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(options.DbUniqueIndexForName);
        }

        #endregion Public methods    
    }
}
