//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTree
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyTree". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleDummyTreeEntityEFShema : SampleEFSchema<SampleDummyTreeEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleDummyTreeEntityEFShema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleDummyTreeEntityEFObject> builder)
        {
            var setting = Settings.DummyTree;

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

            builder.Property(x => x.ParentId)
                .HasColumnName(setting.DbColumnNameForParentId);

            builder.Property(x => x.TreeChildCount)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnNameForTreeChildCount);

            builder.Property(x => x.TreeDescendantCount)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnNameForTreeDescendantCount);

            builder.Property(x => x.TreeLevel)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnNameForTreeLevel);

            builder.Property(x => x.TreePath)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(setting.DbMaxLengthForTreePath)
                .HasDefaultValue(string.Empty)
                .HasColumnName(setting.DbColumnNameForTreePath);

            builder.Property(x => x.TreePosition)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnNameForTreePosition);

            builder.Property(x => x.TreeSort)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(setting.DbMaxLengthForTreeSort)
                .HasDefaultValue(string.Empty)
                .HasColumnName(setting.DbColumnNameForTreeSort);

            builder.HasIndex(x => x.Name).HasDatabaseName(setting.DbIndexForName);
            builder.HasIndex(x => x.ParentId).HasDatabaseName(setting.DbIndexForParentId);
            builder.HasIndex(x => x.TreeSort).HasDatabaseName(setting.DbIndexForTreeSort);

            builder.HasIndex(x => new { x.ParentId, x.Name })
                .IsUnique()
                .HasDatabaseName(setting.DbUniqueIndexForParentIdAndName);

            builder.HasOne(x => x.ObjectDummyTreeParent)
                .WithMany(x => x.ObjectsDummyTreeChild)
                .HasForeignKey(x => x.ParentId)
                .HasConstraintName(setting.DbForeignKeyToParentDummyTree);
        }

        #endregion Public methods    }
    }
}
