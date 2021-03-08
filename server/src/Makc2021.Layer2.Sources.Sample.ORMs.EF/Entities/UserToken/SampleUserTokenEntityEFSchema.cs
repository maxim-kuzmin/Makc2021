//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserToken
{
    /// <summary>
    /// Источник "Sample". Сущность "UserToken". ORM "Entity Framework". Схема.
    /// </summary>
    public class SampleUserTokenEntityEFSchema : SampleEFSchema<SampleUserTokenEntityEFObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleUserTokenEntityEFSchema(SampleSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<SampleUserTokenEntityEFObject> builder)
        {
            var setting = Settings.UserToken;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name }).HasName(setting.DbPrimaryKey);

            builder.Property(x => x.LoginProvider)
                .HasColumnName(setting.DbColumnNameForLoginProvider);

            builder.Property(x => x.Name)
                .HasColumnName(setting.DbColumnNameForName);

            builder.Property(x => x.Value)
                .HasColumnName(setting.DbColumnNameForValue);

            builder.Property(x => x.UserId)
                .HasColumnName(setting.DbColumnNameForUserId);

            builder.HasOne(x => x.ObjectUser)
                .WithMany(x => x.ObjectsUserToken)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName(setting.DbForeignKeyToUser);
        }

        #endregion Public methods    
    }
}
