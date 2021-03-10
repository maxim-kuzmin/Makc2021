//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTree
{
    /// <summary>
    /// Сущность "DummyTree". ORM "Entity Framework". Схема.
    /// </summary>
    public class DummyTreeEntityEFSchema : EFSchema<DummyTreeEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyTreeEntityEFSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DummyTreeEntityEFObject> builder)
        {
            var setting = EntitiesSettings.DummyTree;

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

            builder.Property(x => x.ParentId)
                .HasColumnName(setting.DbColumnForDummyTreeEntityParentId);

            builder.Property(x => x.TreeChildCount)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnForTreeChildCount);

            builder.Property(x => x.TreeDescendantCount)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnForTreeDescendantCount);

            builder.Property(x => x.TreeLevel)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnForTreeLevel);

            builder.Property(x => x.TreePath)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(setting.DbMaxLengthForTreePath)
                .HasDefaultValue(string.Empty)
                .HasColumnName(setting.DbColumnForTreePath);

            builder.Property(x => x.TreePosition)
                .IsRequired()
                .HasDefaultValue(0)
                .HasColumnName(setting.DbColumnForTreePosition);

            builder.Property(x => x.TreeSort)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(setting.DbMaxLengthForTreeSort)
                .HasDefaultValue(string.Empty)
                .HasColumnName(setting.DbColumnForTreeSort);

            builder.HasIndex(x => x.Name).HasDatabaseName(setting.DbIndexForName);
            builder.HasIndex(x => x.ParentId).HasDatabaseName(setting.DbIndexForDummyTreeEntityParentId);
            builder.HasIndex(x => x.TreeSort).HasDatabaseName(setting.DbIndexForTreeSort);

            builder.HasIndex(x => new { x.ParentId, x.Name })
                .IsUnique()
                .HasDatabaseName(setting.DbUniqueIndexForDummyTreeEntityParentIdAndName);

            builder.HasOne(x => x.ObjectOfDummyTreeEntityParent)
                .WithMany(x => x.ObjectsOfDummyTreeEntityChild)
                .HasForeignKey(x => x.ParentId)
                .HasConstraintName(setting.DbForeignKeyToDummyTreeEntityParent);
        }

        #endregion Public methods
    }
}
