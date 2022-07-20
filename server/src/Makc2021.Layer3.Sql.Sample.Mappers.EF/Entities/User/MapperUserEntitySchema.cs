// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User
{
    /// <summary>
    /// Схема сущности "User" сопоставителя.
    /// </summary>
    public class MapperUserEntitySchema : MapperSchema<MapperUserEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserEntitySchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserEntityObject> builder)
        {
            Sample.Entities.User.UserEntitySettings setting = EntitiesOptions.User;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.AccessFailedCount)
                .HasColumnName(setting.DbColumnForAccessFailedCount);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(setting.DbColumnForConcurrencyStamp);

            builder.Property(x => x.Email)
                .HasColumnName(setting.DbColumnForEmail);

            builder.Property(x => x.EmailConfirmed)
                .HasColumnName(setting.DbColumnForEmailConfirmed);

            builder.Property(x => x.FullName)
                .IsUnicode()
                .HasMaxLength(256)
                .HasColumnName(setting.DbColumnForFullName);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.LockoutEnabled)
                .HasColumnName(setting.DbColumnForLockoutEnabled);

            builder.Property(x => x.LockoutEnd)
                .HasColumnName(setting.DbColumnForLockoutEnd);

            builder.Property(x => x.NormalizedEmail)
                .HasColumnName(setting.DbColumnForNormalizedEmail);

            builder.Property(x => x.NormalizedUserName)
                .HasColumnName(setting.DbColumnForNormalizedUserName);

            builder.Property(x => x.PasswordHash)
                .HasColumnName(setting.DbColumnForPasswordHash);

            builder.Property(x => x.PhoneNumber)
                .HasColumnName(setting.DbColumnForPhoneNumber);

            builder.Property(x => x.PhoneNumberConfirmed)
                .HasColumnName(setting.DbColumnForPhoneNumberConfirmed);

            builder.Property(x => x.SecurityStamp)
                .HasColumnName(setting.DbColumnForSecurityStamp);

            builder.Property(x => x.TwoFactorEnabled)
                .HasColumnName(setting.DbColumnForTwoFactorEnabled);

            builder.Property(x => x.UserName)
                .HasColumnName(setting.DbColumnForUserName);

            builder.HasIndex(x => x.NormalizedUserName).IsUnique().HasDatabaseName(setting.DbUniqueIndexForNormalizedUserName);
            builder.HasIndex(x => x.NormalizedEmail).HasDatabaseName(setting.DbIndexForNormalizedEmail);
        }

        #endregion Public methods    
    }
}
