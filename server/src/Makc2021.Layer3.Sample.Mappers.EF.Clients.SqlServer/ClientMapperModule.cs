//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer
{
    using Makc2021.Layer1;

    /// <summary>
    /// Модуль ORM клиента.
    /// </summary>
    public class ClientMapperModule
    {
        #region Properties

        private ClientMapperConfig Config { get; set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public ClientMapperContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => Context.ConfigSettings);
            services.AddTransient(x => Context.DbFactory);
            services.AddTransient(x => Context.EntitiesSettings);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(Environment environment)
        {
            Config = new(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(ClientMapperExternals externals)
        {
            Context = new(Config.Settings, externals);

            Config = null;
        }

        #endregion Public methods
    }
}
