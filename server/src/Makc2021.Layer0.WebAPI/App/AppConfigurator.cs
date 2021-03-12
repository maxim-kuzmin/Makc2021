//Author Maxim Kuzmin//makc//

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

            Module.SampleMapper.ConfigureServices(services);
            Module.SampleClient.ConfigureServices(services);
        }

        #endregion Public methods

        #region Private methods

        private void InitContexts()
        {
            Module.SampleClient.InitContext(new()
            {
                Environment = Environment
            });

            Module.SampleMapper.InitContext(new()
            {
                DbFactory = GetSampleDbFactory(),
                EntitiesSettings = GetSampleEntitiesSettings()
            });
        }

        private void InitConfigs()
        {
            Module.SampleMapper.InitConfig(Environment);
            Module.SampleClient.InitConfig(Environment);
        }

        private Layer3.Sample.Mappers.EF.Db.IMapperDbFactory GetSampleDbFactory()
        {
            return Module.SampleClient.Context.DbFactory;
        }

        private Layer3.Sample.EntitiesSettings GetSampleEntitiesSettings()
        {
            return Module.SampleClient.Context.EntitiesSettings;
        }

        #endregion Private methods
    }
}
