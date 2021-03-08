//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.RoleClaim
{
    /// <summary>
    /// Источник "Sample". Сущность "RoleClaim". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleRoleClaimEntityEFSchema : SampleEFSchema<SampleRoleClaimEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleRoleClaimEntityEFSchema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleRoleClaimEntityEFObject> builder)
        {
            var setting = Settings.RoleClaim;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ClaimType)
                .HasColumnName(setting.DbColumnNameForClaimType);

            builder.Property(x => x.ClaimValue)
                .HasColumnName(setting.DbColumnNameForClaimValue);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.RoleId)
                .HasColumnName(setting.DbColumnNameForRoleId);

            builder.HasIndex(x => x.RoleId).IsUnique().HasDatabaseName(setting.DbUniqueIndexForRoleId);

            builder.HasOne(x => x.ObjectRole)
                .WithMany(x => x.ObjectsRoleClaim)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRole);
        }

        #endregion Public methods    
    }
}
