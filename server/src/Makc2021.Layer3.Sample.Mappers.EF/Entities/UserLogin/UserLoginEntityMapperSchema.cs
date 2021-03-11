//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.UserLogin
{
    /// <summary>
    /// Схема ORM сущности "UserLogin".
    /// </summary>
    public class UserLoginEntityMapperSchema : MapperSchema<UserLoginEntityMapperObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserLoginEntityMapperSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<UserLoginEntityMapperObject> builder)
        {
            var setting = EntitiesSettings.UserLogin;

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
