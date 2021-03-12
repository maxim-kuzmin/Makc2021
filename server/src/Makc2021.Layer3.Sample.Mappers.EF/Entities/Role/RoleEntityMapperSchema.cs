// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.Role
{
    /// <summary>
    /// Схема ORM сущности "Role".
    /// </summary>
    public class RoleEntityMapperSchema : MapperSchema<RoleEntityMapperObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleEntityMapperSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<RoleEntityMapperObject> builder)
        {
            var setting = EntitiesSettings.Role;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName(setting.DbColumnForConcurrencyStamp);

            builder.Property(x => x.Id)
                .HasColumnName(setting.DbColumnForId);

            builder.Property(x => x.Name)
                .HasColumnName(setting.DbColumnForName);

            builder.Property(x => x.NormalizedName)
                .HasColumnName(setting.DbColumnForNormalizedName);

            builder.HasIndex(x => x.NormalizedName).IsUnique().HasDatabaseName(setting.DbUniqueIndexForNormalizedName);
        }

        #endregion Public methods    
    }
}
