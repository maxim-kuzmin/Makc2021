//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.Role
{
    /// <summary>
    /// Источник "Sample". Сущность "Role". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleRoleEntityEFShema : SampleEFSchema<SampleRoleEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleRoleEntityEFShema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleRoleEntityEFObject> builder)
        {
            var setting = Settings.Role;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(setting.DbColumnNameForConcurrencyStamp);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.Name)
                .HasColumnName(setting.DbColumnNameForName);

            builder.Property(x => x.NormalizedName)
                .HasColumnName(setting.DbColumnNameForNormalizedName);

            builder.HasIndex(x => x.NormalizedName).IsUnique().HasDatabaseName(setting.DbUniqueIndexForNormalizedName);
        }

        #endregion Public methods    
    }
}
