//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.ORMs.EF.Db;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMain;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyManyToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyOneToMany;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTree;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTreeLink;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.Role;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.RoleClaim;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.User;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserClaim;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserLogin;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserRole;
using Makc2021.Layer3.Sample.ORMs.EF.Entities.UserToken;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Db
{
    /// <summary>
    /// ORM "Entity Framework". База данных "Microsoft SQL Server". Контекст базы данных.
    /// </summary>
    public class EFSqlServerDbContext : EFDbContext
    {
        #region Properties

        private Settings Settings { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public EFSqlServerDbContext()
            : this(
                  EFSqlServerDbFactory.Default.Options,
                  EFSqlServerDbFactory.Default.Settings
                  )
        {
        }

        /// <inheritdoc/>
        public EFSqlServerDbContext(DbContextOptions<EFDbContext> options)
            : this(options, EFSqlServerDbFactory.Default.Settings)
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        /// <param name="settings">Настройки.</param>
        public EFSqlServerDbContext(
            DbContextOptions<EFDbContext> options,
            Settings settings
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

            modelBuilder.ApplyConfiguration(new DummyMainEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyManyToManyEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyMainDummyManyToManyEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyOneToManyEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyTreeEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new DummyTreeLinkEntityEFSchema(Settings));

            modelBuilder.ApplyConfiguration(new RoleEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new RoleClaimEntityEFSchema(Settings));

            modelBuilder.ApplyConfiguration(new UserEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new UserClaimEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new UserLoginEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new UserRoleEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new UserTokenEntityEFSchema(Settings));
        }

        #endregion Protected methods
    }
}
