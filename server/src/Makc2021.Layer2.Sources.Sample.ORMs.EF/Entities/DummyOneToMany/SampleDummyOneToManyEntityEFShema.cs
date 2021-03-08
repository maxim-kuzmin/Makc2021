//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyOneToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyOneToMany". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleDummyOneToManyEntityEFShema : SampleEFSchema<SampleDummyOneToManyEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleDummyOneToManyEntityEFShema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleDummyOneToManyEntityEFObject> builder)
        {
            var setting = Settings.DummyOneToMany;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(setting.DbMaxLengthForName)
                .HasColumnName(setting.DbColumnNameForName);

            builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(setting.DbUniqueIndexForName);
        }

        #endregion Public methods    
    }
}
