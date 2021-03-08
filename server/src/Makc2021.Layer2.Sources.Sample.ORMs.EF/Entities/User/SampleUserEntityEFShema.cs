//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.User
{
    /// <summary>
    /// Источник "Sample". Сущность "User". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleUserEntityEFShema : SampleEFSchema<SampleUserEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleUserEntityEFShema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleUserEntityEFObject> builder)
        {
            var setting = Settings.User;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.AccessFailedCount)
                .HasColumnName(setting.DbColumnNameForAccessFailedCount);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(setting.DbColumnNameForConcurrencyStamp);

            builder.Property(x => x.Email)
                .HasColumnName(setting.DbColumnNameForEmail);

            builder.Property(x => x.EmailConfirmed)
                .HasColumnName(setting.DbColumnNameForEmailConfirmed);

            builder.Property(x => x.FullName)
                .IsUnicode()
                .HasMaxLength(256)
                .HasColumnName(setting.DbColumnNameForFullName);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.LockoutEnabled)
                .HasColumnName(setting.DbColumnNameForLockoutEnabled);

            builder.Property(x => x.LockoutEnd)
                .HasColumnName(setting.DbColumnNameForLockoutEnd);

            builder.Property(x => x.NormalizedEmail)
                .HasColumnName(setting.DbColumnNameForNormalizedEmail);

            builder.Property(x => x.NormalizedUserName)
                .HasColumnName(setting.DbColumnNameForNormalizedUserName);

            builder.Property(x => x.PasswordHash)
                .HasColumnName(setting.DbColumnNameForPasswordHash);

            builder.Property(x => x.PhoneNumber)
                .HasColumnName(setting.DbColumnNameForPhoneNumber);

            builder.Property(x => x.PhoneNumberConfirmed)
                .HasColumnName(setting.DbColumnNameForPhoneNumberConfirmed);

            builder.Property(x => x.SecurityStamp)
                .HasColumnName(setting.DbColumnNameForSecurityStamp);

            builder.Property(x => x.TwoFactorEnabled)
                .HasColumnName(setting.DbColumnNameForTwoFactorEnabled);

            builder.Property(x => x.UserName)
                .HasColumnName(setting.DbColumnNameForUserName);

            builder.HasIndex(x => x.NormalizedUserName).IsUnique().HasDatabaseName(setting.DbUniqueIndexForNormalizedUserName);
            builder.HasIndex(x => x.NormalizedEmail).HasDatabaseName(setting.DbIndexForNormalizedEmail);
        }

        #endregion Public methods    
    }
}
