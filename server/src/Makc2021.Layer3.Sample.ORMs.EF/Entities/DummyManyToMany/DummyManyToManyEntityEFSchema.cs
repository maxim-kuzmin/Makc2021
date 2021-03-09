//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyManyToMany
{
    /// <summary>
    /// Сущность "DummyManyToMany". ORM "Entity Framework". Схема.
    /// </summary>
    public class DummyManyToManyEntityEFSchema : EFSchema<DummyManyToManyEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyManyToManyEntityEFSchema(Settings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DummyManyToManyEntityEFObject> builder)
        {
            var setting = Settings.DummyManyToMany;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(setting.DbMaxLengthForName)
                .HasColumnName(setting.DbColumnForName);

            builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(setting.DbUniqueIndexForName);
        }

        #endregion Public methods
    }
}
