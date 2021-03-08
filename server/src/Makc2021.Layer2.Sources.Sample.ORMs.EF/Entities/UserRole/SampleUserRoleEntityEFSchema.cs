//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserRole
{
    /// <summary>
    /// Источник "Sample". Сущность "UserRole". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleUserRoleEntityEFSchema : SampleEFSchema<SampleUserRoleEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleUserRoleEntityEFSchema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleUserRoleEntityEFObject> builder)
        {
            var setting = Settings.UserRole;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.UserId, x.RoleId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForUserId);

            builder.Property(x => x.RoleId)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForRoleId);

            builder.HasIndex(x => x.RoleId).HasDatabaseName(setting.DbIndexForRoleId);

            builder.HasOne(x => x.ObjectUser)
                .WithMany(x => x.ObjectsUserRole)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUser);

            builder.HasOne(x => x.ObjectRole)
                .WithMany(x => x.ObjectsUserRole)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRole);
        }

        #endregion Public methods    
    }
}
