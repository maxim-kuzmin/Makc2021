//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.Db;
using Makc2021.Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer.Db
{
    /// <summary>
    /// Источник "Sample". ORM "Entity Framework". База данных "Microsoft SQL Server". Фабрика базы данных.
    /// </summary>
    public class SampleEFSqlServerDbFactory : SampleEFDbFactory, IDesignTimeDbContextFactory<SampleEFSqlServerDbContext>
    {
        #region Properties

        /// <summary>
        /// Экземпляр по умолчанию.
        /// </summary>
        public static SampleEFSqlServerDbFactory Default { get; } = new SampleEFSqlServerDbFactory();

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public SampleEFSqlServerDbFactory()
            : base()
        {
        }

        /// <inheritdoc/>
        public SampleEFSqlServerDbFactory(
            string connectionString,
            SampleSettings settings,
            Environment environment
            )
            : base(connectionString, settings, environment)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public SampleEFSqlServerDbContext CreateDbContext(string[] args)
        {
            return new SampleEFSqlServerDbContext(Options, Settings);
        }

        /// <inheritdoc/>
        public sealed override SampleEFDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override string CreateConnectionString()
        {
            var configFilePath = SampleEFSqlServerConfig.CreateFilePath();

            var configSettings = SampleEFSqlServerConfigSettings.Create(configFilePath, Environment);

            return configSettings.ConnectionString;
        }

        /// <inheritdoc/>
        protected sealed override SampleSettings CreateSettings()
        {
            return SampleEFSqlServerSettings.Instance;
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

