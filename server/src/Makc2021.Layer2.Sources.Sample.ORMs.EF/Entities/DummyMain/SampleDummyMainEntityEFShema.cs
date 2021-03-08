//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMain
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyMain". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleDummyMainEntityEFShema : SampleEFSchema<SampleDummyMainEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleDummyMainEntityEFShema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleDummyMainEntityEFObject> builder)
        {
            var setting = Settings.DummyMain;

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

            builder.Property(x => x.ObjectDummyOneToManyId)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForObjectDummyOneToManyId);

            builder.Property(x => x.PropBoolean)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForPropBoolean);

            builder.Property(x => x.PropBooleanNullable)
                .HasColumnName(setting.DbColumnNameForPropBooleanNullable);

            builder.Property(x => x.PropDate)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForPropDate);

            builder.Property(x => x.PropDateNullable)
                .HasColumnName(setting.DbColumnNameForPropDateNullable);

            builder.Property(x => x.PropDateTimeOffset)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForPropDateTimeOffset);

            builder.Property(x => x.PropDateTimeOffsetNullable)
                .HasColumnName(setting.DbColumnNameForPropDateTimeOffsetNullable);

            builder.Property(x => x.PropDecimal)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForPropDecimal);

            builder.Property(x => x.PropDecimalNullable)
                .HasColumnName(setting.DbColumnNameForPropDecimalNullable);

            builder.Property(x => x.PropInt32)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForPropInt32);

            builder.Property(x => x.PropInt32Nullable)
                .HasColumnName(setting.DbColumnNameForPropInt32Nullable);

            builder.Property(x => x.PropInt64)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForPropInt64);

            builder.Property(x => x.PropInt64Nullable)
                .HasColumnName(setting.DbColumnNameForPropInt64Nullable);

            builder.Property(x => x.PropString)
                .IsRequired()
                .IsUnicode()
                .HasColumnName(setting.DbColumnNameForPropString);

            builder.Property(x => x.PropStringNullable)
                .IsUnicode()
                .HasColumnName(setting.DbColumnNameForPropStringNullable);

            builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(setting.DbUniqueIndexForName);
            builder.HasIndex(x => x.ObjectDummyOneToManyId).HasDatabaseName(setting.DbIndexForObjectDummyOneToManyId);

            builder.HasOne(x => x.ObjectDummyOneToMany)
                .WithMany(x => x.ObjectsDummyMain)
                .HasForeignKey(x => x.ObjectDummyOneToManyId)
                .HasConstraintName(setting.DbForeignKeyToDummyOneToMany);
        }

        #endregion Public methods
    }
}
