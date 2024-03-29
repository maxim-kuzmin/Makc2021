﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.Role
{
    /// <summary>
    /// Схема сущности "Role" для сопоставителя.
    /// </summary>
    public class MapperRoleEntitySchema : MapperSchema<MapperRoleEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperRoleEntitySchema(EntitiesOptions entitiesOptions)
            : base(entitiesOptions)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperRoleEntityObject> builder)
        {
            var options = EntitiesOptions.Role;

            builder.ToTable(options.DbTable, options.DbSchema);

            builder.HasKey(x => x.Id).HasName(options.DbPrimaryKey);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(options.DbColumnForConcurrencyStamp);

            builder.Property(x => x.Id)
                .HasColumnName(options.DbColumnForId);

            builder.Property(x => x.Name)
                .HasColumnName(options.DbColumnForName);

            builder.Property(x => x.NormalizedName)
                .HasColumnName(options.DbColumnForNormalizedName);

            builder.HasIndex(x => x.NormalizedName).IsUnique().HasDatabaseName(options.DbUniqueIndexForNormalizedName);
        }

        #endregion Public methods    
    }
}
