//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer3.Sample.ORMs.EF.Db;
using Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Db
{
    /// <summary>
    /// ORM "Entity Framework". База данных "Microsoft SQL Server". Фабрика базы данных.
    /// </summary>
    public class EFSqlServerDbFactory : EFDbFactory, IDesignTimeDbContextFactory<EFSqlServerDbContext>
    {
        #region Properties

        /// <summary>
        /// Экземпляр по умолчанию.
        /// </summary>
        public static EFSqlServerDbFactory Default { get; } = new();

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public EFSqlServerDbFactory()
            : base()
        {
        }

        /// <inheritdoc/>
        public EFSqlServerDbFactory(
            string connectionString,
            EntitiesSettings settings,
            Environment environment
            )
            : base(connectionString, settings, environment)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public EFSqlServerDbContext CreateDbContext(string[] args)
        {
            return new EFSqlServerDbContext(Options, Settings);
        }

        /// <inheritdoc/>
        public sealed override EFDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override string CreateConnectionString()
        {
            var configFilePath = EFSqlServerConfig.CreateFilePath();

            var configSettings = EFSqlServerConfigSettings.Create(configFilePath, Environment);

            return configSettings.ConnectionString;
        }

        /// <inheritdoc/>
        protected sealed override EntitiesSettings CreateSettings()
        {
            return EFSqlServerEntitiesSettings.Instance;
        }

        /// <inheritdoc/>
        public sealed override void BuildDbContextOptions(DbContextOptionsBuilder builder)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            builder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly(assemblyName));
        }

        #endregion Protected methods
    }
}

