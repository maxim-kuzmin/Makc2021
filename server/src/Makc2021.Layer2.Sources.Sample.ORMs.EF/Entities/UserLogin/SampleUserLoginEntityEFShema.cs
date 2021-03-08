//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserLogin
{
    /// <summary>
    /// Источник "Sample". Сущность "UserLogin". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleUserLoginEntityEFShema : SampleEFSchema<SampleUserLoginEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleUserLoginEntityEFShema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleUserLoginEntityEFObject> builder)
        {
            var setting = Settings.UserLogin;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.LoginProvider, x.ProviderKey })
                .HasName(setting.DbPrimaryKey);

            builder.Property(x => x.LoginProvider)
                .HasColumnName(setting.DbColumnNameForLoginProvider);

            builder.Property(x => x.ProviderDisplayName)
                .HasColumnName(setting.DbColumnNameForProviderDisplayName);

            builder.Property(x => x.ProviderKey)
                .HasColumnName(setting.DbColumnNameForProviderKey);

            builder.Property(x => x.UserId)
                .HasColumnName(setting.DbColumnNameForUserId);

            builder.HasIndex(x => x.UserId).HasDatabaseName(setting.DbIndexForUserId);

            builder.HasOne(x => x.ObjectUser)
                .WithMany(x => x.ObjectsUserLogin)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUser);
        }

        #endregion Public methods    
    }
}
