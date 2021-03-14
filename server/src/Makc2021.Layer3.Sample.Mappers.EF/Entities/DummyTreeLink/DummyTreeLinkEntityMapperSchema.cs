// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Схема сущности "DummyTreeLink" для сопоставителя.
    /// </summary>
    public class DummyTreeLinkEntityMapperSchema : MapperSchema<DummyTreeLinkEntityMapperObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyTreeLinkEntityMapperSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DummyTreeLinkEntityMapperObject> builder)
        {
            Sample.Entities.DummyTreeLink.DummyTreeLinkEntitySetting setting = EntitiesSettings.DummyTreeLink;

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
