﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserRole
{
    /// <summary>
    /// Схема сущности "UserRole" сопоставителя.
    /// </summary>
    public class MapperUserRoleEntitySchema : MapperSchema<MapperUserRoleEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserRoleEntitySchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserRoleEntityObject> builder)
        {
            Sample.Entities.UserRole.UserRoleEntitySettings setting = EntitiesSettings.UserRole;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.UserId, x.RoleId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForUserEntityId);

            builder.Property(x => x.RoleId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForRoleEntityId);

            builder.HasIndex(x => x.RoleId).HasDatabaseName(setting.DbIndexForRoleEntityId);

            builder.HasOne(x => x.ObjectOfUserEntity)
                .WithMany(x => x.ObjectsOfUserRoleEntity)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUserEntity);

            builder.HasOne(x => x.ObjectOfRoleEntity)
                .WithMany(x => x.ObjectsOfUserRoleEntity)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRoleEntity);
        }

        #endregion Public methods    
    }
}
