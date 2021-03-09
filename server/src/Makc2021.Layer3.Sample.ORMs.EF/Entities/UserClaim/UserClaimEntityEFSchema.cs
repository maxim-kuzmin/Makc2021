//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserClaim
{
    /// <summary>
    /// Сущность "UserClaim". ORM "Entity Framework". Схема.
    /// </summary>
    public class UserClaimEntityEFSchema : EFSchema<UserClaimEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserClaimEntityEFSchema(Settings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<UserClaimEntityEFObject> builder)
        {
            var setting = Settings.UserClaim;

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
