//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Mappers.EF;
using Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer0.WebAPI.App
{
    using Makc2021.Layer1;

    /// <summary>
    /// Конфигуратор приложения.
    /// </summary>
    public class AppConfigurator
    {
        #region Properties

        private Environment Environment { get; } = new();

        private AppModule Module { get; } = new();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        public void Configure()
        {
        }

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            InitConfigs();
            InitContexts();

            Module.EF.ConfigureServices(services);
            Module.EFSqlServer.ConfigureServices(services);
        }

        #endregion Public methods

        #region Private methods

        private void InitContexts()
        {
            Module.EFSqlServer.InitContext(new ClientMapperExternals
            {
                Environment = Environment
            });

            Module.EF.InitContext(new MapperExternals
            {
                DbFactory = Module.EFSqlServer.Context.DbFactory,
                EntitiesSettings = Module.EFSqlServer.Context.EntitiesSettings
            });
        }

        private void InitConfigs()
        {
            Module.EF.InitConfig(Environment);
            Module.EFSqlServer.InitConfig(Environment);
        }

        #endregion Private methods
    }
}
