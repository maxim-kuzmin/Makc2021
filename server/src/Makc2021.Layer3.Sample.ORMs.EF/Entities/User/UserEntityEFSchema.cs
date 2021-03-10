//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.User
{
    /// <summary>
    /// Сущность "User". ORM "Entity Framework". Схема.
    /// </summary>
    public class UserEntityEFSchema : EFSchema<UserEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserEntityEFSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<UserEntityEFObject> builder)
        {
            var setting = EntitiesSettings.User;

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
