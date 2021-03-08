//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyTreeLink". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleDummyTreeLinkEntityEFShema : SampleEFSchema<SampleDummyTreeLinkEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleDummyTreeLinkEntityEFShema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleDummyTreeLinkEntityEFObject> builder)
        {
            var setting = Settings.DummyTreeLink;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.Id, x.ParentId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForId);

            builder.Property(x => x.ParentId)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForParentId);

            builder.HasOne(x => x.ObjectDummyTree)
                .WithMany(x => x.ObjectsDummyTreeLink)
                .HasForeignKey(x => x.Id)
                .HasConstraintName(setting.DbForeignKeyToDummyTree);
        }

        #endregion Public methods    }
    }
}
