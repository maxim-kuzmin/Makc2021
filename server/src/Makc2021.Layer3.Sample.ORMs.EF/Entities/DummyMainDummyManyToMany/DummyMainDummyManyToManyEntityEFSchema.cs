//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность "DummyMainDummyManyToMany". ORM "Entity Framework". Схема.
    /// </summary>
    public class DummyMainDummyManyToManyEntityEFSchema : EFSchema<DummyMainDummyManyToManyEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainDummyManyToManyEntityEFSchema(Settings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DummyMainDummyManyToManyEntityEFObject> builder)
        {
            var setting = Settings.DummyMainDummyManyToMany;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.ObjectDummyMainId, x.ObjectDummyManyToManyId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ObjectDummyMainId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyMainEntityId);

            builder.Property(x => x.ObjectDummyManyToManyId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyManyToManyEntityId);

            builder.HasIndex(x => x.ObjectDummyManyToManyId).HasDatabaseName(setting.DbIndexForDummyManyToManyEntityId);

            builder.HasOne(x => x.ObjectOfDummyMainEntity)
                .WithMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .HasForeignKey(x => x.ObjectDummyMainId)
                .HasConstraintName(setting.DbForeignKeyToDummyMainEntity);

            builder.HasOne(x => x.ObjectOfDummyManyToManyEntity)
                .WithMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .HasForeignKey(x => x.ObjectDummyManyToManyId)
                .HasConstraintName(setting.DbForeignKeyToDummyManyToManyEntity);
        }

        #endregion Public methods
    }
}
