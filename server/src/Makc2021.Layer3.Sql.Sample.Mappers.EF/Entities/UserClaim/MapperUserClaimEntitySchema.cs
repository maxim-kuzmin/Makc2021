// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim
{
    /// <summary>
    /// Схема сущности "UserClaim" сопоставителя.
    /// </summary>
    public class MapperUserClaimEntitySchema : MapperSchema<MapperUserClaimEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserClaimEntitySchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserClaimEntityObject> builder)
        {
            Sample.Entities.UserClaim.UserClaimEntitySettings setting = EntitiesSettings.UserClaim;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ClaimType)
                .HasColumnName(setting.DbColumnForClaimType);

            builder.Property(x => x.ClaimValue)
                .HasColumnName(setting.DbColumnForClaimValue);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.UserId)
                .HasColumnName(setting.DbColumnForUserEntityId);

            builder.HasIndex(x => x.UserId).HasDatabaseName(setting.DbIndexForUserEntityId);

            builder.HasOne(x => x.ObjectOfUserEntity)
                .WithMany(x => x.ObjectsOfUserClaimEntity)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUserEntity);
        }

        #endregion Public methods    
    }
}
