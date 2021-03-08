//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserClaim
{
    /// <summary>
    /// Источник "Sample". Сущность "UserClaim". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleUserClaimEntityEFShema : SampleEFSchema<SampleUserClaimEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleUserClaimEntityEFShema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleUserClaimEntityEFObject> builder)
        {
            var setting = Settings.UserClaim;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ClaimType)
                .HasColumnName(setting.DbColumnNameForClaimType);

            builder.Property(x => x.ClaimValue)
                .HasColumnName(setting.DbColumnNameForClaimValue);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.UserId)
                .HasColumnName(setting.DbColumnNameForUserId);

            builder.HasIndex(x => x.UserId).HasDatabaseName(setting.DbIndexForUserId);

            builder.HasOne(x => x.ObjectUser)
                .WithMany(x => x.ObjectsUserClaim)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUser);
        }

        #endregion Public methods    
    }
}
