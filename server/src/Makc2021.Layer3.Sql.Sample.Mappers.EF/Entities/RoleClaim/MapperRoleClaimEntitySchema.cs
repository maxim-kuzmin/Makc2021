﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim
{
    /// <summary>
    /// Схема сущности "RoleClaim" для сопоставителя.
    /// </summary>
    public class MapperRoleClaimEntitySchema : MapperSchema<MapperRoleClaimEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperRoleClaimEntitySchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperRoleClaimEntityObject> builder)
        {
            Sample.Entities.RoleClaim.RoleClaimEntitySettings setting = EntitiesOptions.RoleClaim;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ClaimType)
                .HasColumnName(setting.DbColumnForClaimType);

            builder.Property(x => x.ClaimValue)
                .HasColumnName(setting.DbColumnForClaimValue);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.RoleId)
                .HasColumnName(setting.DbColumnForRoleEntityId);

            builder.HasIndex(x => x.RoleId).IsUnique().HasDatabaseName(setting.DbUniqueIndexForRoleEntityId);

            builder.HasOne(x => x.ObjectOfRoleEntity)
                .WithMany(x => x.ObjectsOfRoleClaimEntity)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRoleEntity);
        }

        #endregion Public methods    
    }
}
