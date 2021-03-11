//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMain;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyOneToMany;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTree;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTreeLink;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.Role;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.RoleClaim;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.User;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserClaim;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserLogin;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserRole;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.UserToken;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer.Db
{
    /// <summary>
    /// Контекст базы данных ORM клиента.
    /// </summary>
    public class ClientMapperDbContext : MapperDbContext
    {
        #region Properties

        private EntitiesSettings Settings { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public ClientMapperDbContext()
            : this(
                  ClientMapperDbFactory.Default.Options,
                  ClientMapperDbFactory.Default.Settings
                  )
        {
        }

        /// <inheritdoc/>
        public ClientMapperDbContext(DbContextOptions<MapperDbContext> options)
            : this(options, ClientMapperDbFactory.Default.Settings)
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        /// <param name="settings">Настройки.</param>
        public ClientMapperDbContext(
            DbContextOptions<MapperDbContext> options,
            EntitiesSettings settings
            )
            : base(options)
        {
            Settings = settings;
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Обработать событие создания модели.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DummyMainEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyManyToManyEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyMainDummyManyToManyEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyOneToManyEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyTreeEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyTreeLinkEntityMapperSchema(Settings));

            modelBuilder.ApplyConfiguration(new RoleEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new RoleClaimEntityMapperSchema(Settings));

            modelBuilder.ApplyConfiguration(new UserEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new UserClaimEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new UserLoginEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new UserRoleEntityMapperSchema(Settings));
            modelBuilder.ApplyConfiguration(new UserTokenEntityMapperSchema(Settings));
        }

        #endregion Protected methods
    }
}
