//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF.Db
{
    /// <summary>
    /// Фабрика базы данных клиента.
    /// </summary>
    public class ClientDbFactory : MapperDbFactory, IDesignTimeDbContextFactory<ClientDbContext>
    {
        #region Properties

        /// <summary>
        /// Экземпляр по умолчанию.
        /// </summary>
        public static IMapperDbFactory Default { get; } = new ClientDbFactory();

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public ClientDbFactory()
            : base()
        {
        }

        /// <inheritdoc/>
        public ClientDbFactory(string connectionString, EntitiesSettings settings, Environment environment)
            : base(connectionString, settings, environment)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public ClientDbContext CreateDbContext(string[] args)
        {
            return new ClientDbContext(Options, EntitiesSettings);
        }

        /// <inheritdoc/>
        public sealed override MapperDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override string CreateConnectionString()
        {
            var configSettings = ClientConfigSettings.Create(ClientConfig.FilePath, Environment);

            return configSettings.ConnectionString;
        }

        /// <inheritdoc/>
        protected sealed override EntitiesSettings CreateEntitiesSettings()
        {
            return ClientEntitiesSettings.Instance;
        }

        /// <inheritdoc/>
        public sealed override void BuildDbContextOptions(DbContextOptionsBuilder builder)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            builder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly(assemblyName));
        }

        #endregion Protected methods
    }
}

