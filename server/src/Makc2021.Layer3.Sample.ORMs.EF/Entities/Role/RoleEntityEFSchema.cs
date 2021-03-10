//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.Role
{
    /// <summary>
    /// Сущность "Role". ORM "Entity Framework". Схема.
    /// </summary>
    public class RoleEntityEFSchema : EFSchema<RoleEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleEntityEFSchema(EntitiesSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<RoleEntityEFObject> builder)
        {
            var setting = Settings.Role;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(setting.DbColumnForConcurrencyStamp);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.Name)
                .HasColumnName(setting.DbColumnForName);

            builder.Property(x => x.NormalizedName)
                .HasColumnName(setting.DbColumnForNormalizedName);

            builder.HasIndex(x => x.NormalizedName).IsUnique().HasDatabaseName(setting.DbUniqueIndexForNormalizedName);
        }

        #endregion Public methods    
    }
}
