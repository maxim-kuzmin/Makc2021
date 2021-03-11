//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.RoleClaim
{
    /// <summary>
    /// Схема ORM сущности "RoleClaim".
    /// </summary>
    public class RoleClaimEntityMapperSchema : MapperSchema<RoleClaimEntityMapperObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleClaimEntityMapperSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<RoleClaimEntityMapperObject> builder)
        {
            var setting = EntitiesSettings.RoleClaim;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ClaimType)
                .HasColumnName(setting.DbColumnForClaimType);

            builder.Property(x => x.ClaimValue)
                .HasColumnName(setting.DbColumnForClaimValue);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.RoleId)
                .HasColumnName(setting.DbColumnForRoleEntityId);

            builder.HasIndex(x => x.RoleId).IsUnique().HasDatabaseName(setting.DbUniqueIndexForRoleEntityId);

            builder.HasOne(x => x.ObjectOfRoleEntity)
                .WithMany(x => x.ObjectsOfRoleClaimEntity)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName(setting.DbForeignKeyToRoleEntity);
        }

        #endregion Public methods    
    }
}
