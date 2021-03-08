//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.ORMs.EF.Db;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMain;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMainDummyManyToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyManyToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyOneToMany;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTree;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTreeLink;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.Role;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.RoleClaim;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.User;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserClaim;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserLogin;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserRole;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserToken;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer.Db
{
    /// <summary>
    /// Источник "Sample". ORM "Entity Framework". База данных "Microsoft SQL Server". Контекст базы данных.
    /// </summary>
    public class SampleEFSqlServerDbContext : SampleEFDbContext
    {
        #region Properties

        private SampleSettings Settings { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public SampleEFSqlServerDbContext()
            : this(
                  SampleEFSqlServerDbFactory.Default.Options,
                  SampleEFSqlServerDbFactory.Default.Settings
                  )
        {
        }

        /// <inheritdoc/>
        public SampleEFSqlServerDbContext(DbContextOptions<SampleEFDbContext> options)
            : this(options, SampleEFSqlServerDbFactory.Default.Settings)
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options">Опции.</param>
        /// <param name="settings">Настройки.</param>
        public SampleEFSqlServerDbContext(
            DbContextOptions<SampleEFDbContext> options,
            SampleSettings settings
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

            modelBuilder.ApplyConfiguration(new SampleDummyMainEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleDummyManyToManyEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleDummyMainDummyManyToManyEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleDummyOneToManyEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleDummyTreeEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleDummyTreeLinkEntityEFSchema(Settings));

            modelBuilder.ApplyConfiguration(new SampleRoleEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleRoleClaimEntityEFSchema(Settings));

            modelBuilder.ApplyConfiguration(new SampleUserEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleUserClaimEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleUserLoginEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleUserRoleEntityEFSchema(Settings));
            modelBuilder.ApplyConfiguration(new SampleUserTokenEntityEFSchema(Settings));
        }

        #endregion Protected methods
    }
}
