//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer.Db
{
    /// <summary>
    /// Фабрика базы данных ORM клиента.
    /// </summary>
    public class ClientMapperDbFactory : MapperDbFactory, IDesignTimeDbContextFactory<ClientMapperDbContext>
    {
        #region Properties

        /// <summary>
        /// Экземпляр по умолчанию.
        /// </summary>
        public static IMapperDbFactory Default { get; } = new ClientMapperDbFactory();

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public ClientMapperDbFactory()
            : base()
        {
        }

        /// <inheritdoc/>
        public ClientMapperDbFactory(string connectionString, EntitiesSettings settings, Environment environment)
            : base(connectionString, settings, environment)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public ClientMapperDbContext CreateDbContext(string[] args)
        {
            return new ClientMapperDbContext(Options, EntitiesSettings);
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
            var configSettings = ClientMapperConfigSettings.Create(ClientMapperConfig.FilePath, Environment);

            return configSettings.ConnectionString;
        }

        /// <inheritdoc/>
        protected sealed override EntitiesSettings CreateEntitiesSettings()
        {
            return ClientMapperEntitiesSettings.Instance;
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

