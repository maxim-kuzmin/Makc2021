//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyMainDummyManyToMany". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleDummyMainDummyManyToManyEntityEFShema : SampleEFSchema<SampleDummyMainDummyManyToManyEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleDummyMainDummyManyToManyEntityEFShema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleDummyMainDummyManyToManyEntityEFObject> builder)
        {
            var setting = Settings.DummyMainDummyManyToMany;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.ObjectDummyMainId, x.ObjectDummyManyToManyId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ObjectDummyMainId)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForObjectDummyMainId);

            builder.Property(x => x.ObjectDummyManyToManyId)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForObjectDummyManyToManyId);

            builder.HasIndex(x => x.ObjectDummyManyToManyId).HasDatabaseName(setting.DbIndexForObjectDummyManyToManyId);

            builder.HasOne(x => x.ObjectDummyMain)
                .WithMany(x => x.ObjectsDummyMainDummyManyToMany)
                .HasForeignKey(x => x.ObjectDummyMainId)
                .HasConstraintName(setting.DbForeignKeyToDummyMain);

            builder.HasOne(x => x.ObjectDummyManyToMany)
                .WithMany(x => x.ObjectsDummyMainDummyManyToMany)
                .HasForeignKey(x => x.ObjectDummyManyToManyId)
                .HasConstraintName(setting.DbForeignKeyToDummyManyToMany);
        }

        #endregion Public methods
    }
}
