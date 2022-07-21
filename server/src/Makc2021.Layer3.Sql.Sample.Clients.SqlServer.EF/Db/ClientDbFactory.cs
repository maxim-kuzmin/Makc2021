// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Reflection;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sql.Sample.Clients.SqlServer.Config;
using Makc2021.Layer3.Sql.Sample.Clients.SqlServer.Entities;
using Makc2021.Layer3.Sql.Sample.Entities;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer3.Sql.Sample.Clients.SqlServer.EF.Db
{
    /// <summary>
    /// Фабрика базы данных клиента.
    /// </summary>
    public class ClientDbFactory : MapperDbFactory, IDesignTimeDbContextFactory<ClientDbContext>
    {
        #region Properties

        private int DbCommandTimeout { get; }

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

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="clientConfigSettings">Конфигурационные настройки клиента.</param>
        /// <param name="dataConfigSettings">Конфигурационные настройки данных.</param>
        /// <param name="entitiesSettings">Настройки сущностей.</param>
        /// <param name="environment">Окружение.</param>
        /// <param name="logger">Регистратор.</param>
        public ClientDbFactory(
            IClientConfigSettings clientConfigSettings,
            Layer2.Sql.Config.IConfigSettings dataConfigSettings,
            EntitiesOptions entitiesSettings,
            CommonEnvironment environment,
            ILogger<ClientDbFactory> logger
            )
            : base(
                  clientConfigSettings.ConnectionString,
                  entitiesSettings,
                  environment,
                  logger,
                  dataConfigSettings.LogLevel
                  )
        {
            DbCommandTimeout = dataConfigSettings.DbCommandTimeout;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public ClientDbContext CreateDbContext(string[] args)
        {
            var result = new ClientDbContext(Options, EntitiesOptions);

            result.Database.SetCommandTimeout(DbCommandTimeout > 0 ? DbCommandTimeout : 3600);

            return result;
        }

        /// <inheritdoc/>
        public sealed override MapperDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void BuildDbContextOptions(DbContextOptionsBuilder builder)
        {
            base.BuildDbContextOptions(builder);

            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            builder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly(assemblyName));
        }

        /// <inheritdoc/>
        protected sealed override string CreateConnectionString()
        {
            IClientConfigSettings configSettings = ClientConfigSettings.Create(ClientConfigSource.FilePath, Environment);

            return configSettings.ConnectionString;
        }

        /// <inheritdoc/>
        protected sealed override EntitiesOptions CreateEntitiesOptions()
        {
            return ClientEntitiesOptions.Instance;
        }

        #endregion Protected methods
    }
}

