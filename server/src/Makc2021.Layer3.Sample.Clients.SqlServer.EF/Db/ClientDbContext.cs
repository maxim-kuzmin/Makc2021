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

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF.Db
{
    /// <summary>
    /// Контекст базы данных клиента.
    /// </summary>
    public class ClientDbContext : MapperDbContext
    {
        #region Fields

        private readonly EntitiesSettings _entitiesSettings;

        #endregion Fields

        #region Constructors

        /// <inheritdoc/>
        public ClientDbContext()
            : this( ClientDbFactory.Default.Options, ClientDbFactory.Default.EntitiesSettings)
        {
        }

        /// <inheritdoc/>
        public ClientDbContext(DbContextOptions<MapperDbContext> options)
            : this(options, ClientDbFactory.Default.EntitiesSettings)
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        /// <param name="entitiesSettings">Настройки сущностей.</param>
        public ClientDbContext(DbContextOptions<MapperDbContext> options, EntitiesSettings entitiesSettings)
            : base(options)
        {
            _entitiesSettings = entitiesSettings;
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DummyMainEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new DummyManyToManyEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new DummyMainDummyManyToManyEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new DummyOneToManyEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new DummyTreeEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new DummyTreeLinkEntityMapperSchema(_entitiesSettings));

            modelBuilder.ApplyConfiguration(new RoleEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new RoleClaimEntityMapperSchema(_entitiesSettings));

            modelBuilder.ApplyConfiguration(new UserEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new UserClaimEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new UserLoginEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new UserRoleEntityMapperSchema(_entitiesSettings));
            modelBuilder.ApplyConfiguration(new UserTokenEntityMapperSchema(_entitiesSettings));
        }

        #endregion Protected methods
    }
}
