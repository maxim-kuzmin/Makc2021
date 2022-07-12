// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserLogin
{
    /// <summary>
    /// Схема сущности "UserLogin" сопоставителя.
    /// </summary>
    public class MapperUserLoginEntitySchema : MapperSchema<MapperUserLoginEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserLoginEntitySchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserLoginEntityObject> builder)
        {
            Sample.Entities.UserLogin.UserLoginEntitySettings setting = EntitiesSettings.UserLogin;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.LoginProvider, x.ProviderKey })
                .HasName(setting.DbPrimaryKey);

            builder.Property(x => x.LoginProvider)
                .HasColumnName(setting.DbColumnForLoginProvider);

            builder.Property(x => x.ProviderDisplayName)
                .HasColumnName(setting.DbColumnForProviderDisplayName);

            builder.Property(x => x.ProviderKey)
                .HasColumnName(setting.DbColumnForProviderKey);

            builder.Property(x => x.UserId)
                .HasColumnName(setting.DbColumnForUserEntityId);

            builder.HasIndex(x => x.UserId).HasDatabaseName(setting.DbIndexForUserEntityId);

            builder.HasOne(x => x.ObjectOfUserEntity)
                .WithMany(x => x.ObjectsOfUserLoginEntity)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUserEntity);
        }

        #endregion Public methods    
    }
}
