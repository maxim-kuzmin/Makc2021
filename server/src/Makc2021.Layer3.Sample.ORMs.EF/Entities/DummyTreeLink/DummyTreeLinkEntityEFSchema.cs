﻿//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Сущность "DummyTreeLink". ORM "Entity Framework". Схема.
    /// </summary>
    public class DummyTreeLinkEntityEFSchema : EFSchema<DummyTreeLinkEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyTreeLinkEntityEFSchema(EntitiesSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DummyTreeLinkEntityEFObject> builder)
        {
            var setting = Settings.DummyTreeLink;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.Id, x.ParentId }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.ParentId)
                .IsRequired()
                .HasColumnName(setting.DbColumnForDummyTreeEntityParentId);

            builder.HasOne(x => x.ObjectOfDummyTreeEntity)
                .WithMany(x => x.ObjectsOfDummyTreeLinkEntity)
                .HasForeignKey(x => x.Id)
                .HasConstraintName(setting.DbForeignKeyToDummyTreeEntity);
        }

        #endregion Public methods
    }
}
