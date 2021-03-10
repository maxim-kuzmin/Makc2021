//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMain
{
    /// <summary>
    /// Сущность "DummyMain". ORM "Entity Framework". Схема.
    /// </summary>
    public class DummyMainEntityEFSchema : EFSchema<DummyMainEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainEntityEFSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DummyMainEntityEFObject> builder)
        {
            var setting = EntitiesSettings.DummyMain;

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

            builder.Property(x => x.ObjectDummyOneToManyId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyOneToManyEntityId);

            builder.Property(x => x.PropBoolean)
                .IsRequired()
                .HasColumnName(setting.DbColumnForPropBoolean);

            builder.Property(x => x.PropBooleanNullable)
                .HasColumnName(setting.DbColumnForPropBooleanNullable);

            builder.Property(x => x.PropDate)
                .IsRequired()
                .HasColumnName(setting.DbColumnForPropDate);

            builder.Property(x => x.PropDateNullable)
                .HasColumnName(setting.DbColumnForPropDateNullable);

            builder.Property(x => x.PropDateTimeOffset)
                .IsRequired()
                .HasColumnName(setting.DbColumnForPropDateTimeOffset);

            builder.Property(x => x.PropDateTimeOffsetNullable)
                .HasColumnName(setting.DbColumnForPropDateTimeOffsetNullable);

            builder.Property(x => x.PropDecimal)
                .IsRequired()
                .HasColumnName(setting.DbColumnForPropDecimal);

            builder.Property(x => x.PropDecimalNullable)
                .HasColumnName(setting.DbColumnForPropDecimalNullable);

            builder.Property(x => x.PropInt32)
                .IsRequired()
                .HasColumnName(setting.DbColumnForPropInt32);

            builder.Property(x => x.PropInt32Nullable)
                .HasColumnName(setting.DbColumnForPropInt32Nullable);

            builder.Property(x => x.PropInt64)
                .IsRequired()
                .HasColumnName(setting.DbColumnForPropInt64);

            builder.Property(x => x.PropInt64Nullable)
                .HasColumnName(setting.DbColumnForPropInt64Nullable);

            builder.Property(x => x.PropString)
                .IsRequired()
                .IsUnicode()
                .HasColumnName(setting.DbColumnForPropString);

            builder.Property(x => x.PropStringNullable)
                .IsUnicode()
                .HasColumnName(setting.DbColumnForPropStringNullable);

            builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(setting.DbUniqueIndexForName);
            builder.HasIndex(x => x.ObjectDummyOneToManyId).HasDatabaseName(setting.DbIndexForDummyOneToManyEntityId);

            builder.HasOne(x => x.ObjectOfDummyOneToManyEntity)
                .WithMany(x => x.ObjectsOfDummyMainEntity)
                .HasForeignKey(x => x.ObjectDummyOneToManyId)
                .HasConstraintName(setting.DbForeignKeyToDummyOneToManyEntity);
        }

        #endregion Public methods
    }
}
