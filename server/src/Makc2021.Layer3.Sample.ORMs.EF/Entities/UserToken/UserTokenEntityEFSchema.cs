//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserToken
{
    /// <summary>
    /// Сущность "UserToken". ORM "Entity Framework". Схема.
    /// </summary>
    public class UserTokenEntityEFSchema : EFSchema<UserTokenEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserTokenEntityEFSchema(EntitiesSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<UserTokenEntityEFObject> builder)
        {
            var setting = Settings.UserToken;

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
