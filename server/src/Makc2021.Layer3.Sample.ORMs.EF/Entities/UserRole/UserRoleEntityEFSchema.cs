//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.UserRole
{
    /// <summary>
    /// Сущность "UserRole". ORM "Entity Framework". Схема.
    /// </summary>
    public class UserRoleEntityEFSchema : EFSchema<UserRoleEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public UserRoleEntityEFSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<UserRoleEntityEFObject> builder)
        {
            var setting = EntitiesSettings.UserRole;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.UserId, x.RoleId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForUserEntityId);

            builder.Property(x => x.RoleId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForRoleEntityId);

            builder.HasIndex(x => x.RoleId).HasDatabaseName(setting.DbIndexForRoleEntityId);

            builder.HasOne(x => x.ObjectOfUserEntity)
                .WithMany(x => x.ObjectsOfUserRoleEntity)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUserEntity);

            builder.HasOne(x => x.ObjectOfRoleEntity)
                .WithMany(x => x.ObjectsOfUserRoleEntity)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRoleEntity);
        }

        #endregion Public methods    
    }
}
