// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Reflection;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Entities;
using Makc2021.Layer3.Sample.Entities;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF.Db
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
        /// <param name="appConfigSettings">Конфигурационные настройки.</param>
        /// <param name="appDataConfigSettings">Конфигурационные настройки данных.</param>
        /// <param name="appEntitiesSettings">Настройки сущностей.</param>
        /// <param name="appEnvironment">Окружение.</param>
        /// <param name="extLogger">Регистратор.</param>
        public ClientDbFactory(
            IClientConfigSettings appClientConfigSettings,
            Layer2.Config.IConfigSettings appDataConfigSettings,
            EntitiesSettings appEntitieSettings,
            CommonEnvironment appEnvironment,
            ILogger<ClientDbFactory> extLogger
            )
            : base(
                  appClientConfigSettings.ConnectionString,
                  appEntitieSettings,
                  appEnvironment,
                  extLogger,
                  appDataConfigSettings.LogLevel
                  )
        {
            DbCommandTimeout = appDataConfigSettings.DbCommandTimeout;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public ClientDbContext CreateDbContext(string[] args)
        {
            var result = new ClientDbContext(Options, EntitiesSettings);

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
        protected sealed override EntitiesSettings CreateEntitiesSettings()
        {
            return ClientEntitiesSettings.Instance;
        }

        #endregion Protected methods
    }
}

