// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserToken
{
    /// <summary>
    /// Схема сущности "UserToken" сопоставителя.
    /// </summary>
    public class MapperUserTokenEntitySchema : MapperSchema<MapperUserTokenEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperUserTokenEntitySchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<MapperUserTokenEntityObject> builder)
        {
            Sample.Entities.UserToken.UserTokenEntitySettings setting = EntitiesSettings.UserToken;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.LoginProvider)
                .HasColumnName(setting.DbColumnForLoginProvider);

            builder.Property(x => x.Name)
                .HasColumnName(setting.DbColumnForName);

            builder.Property(x => x.Value)
                .HasColumnName(setting.DbColumnForValue);

            builder.Property(x => x.UserId)
                .HasColumnName(setting.DbColumnForUserEntityId);

            builder.HasOne(x => x.ObjectOfUserEntity)
                .WithMany(x => x.ObjectsOfUserTokenEntity)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUserEntity);
        }

        #endregion Public methods    
    }
}
