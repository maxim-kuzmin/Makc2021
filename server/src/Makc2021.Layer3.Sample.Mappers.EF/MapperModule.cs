//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    using Makc2021.Layer1;

    /// <summary>
    /// Модуль ORM.
    /// </summary>
    public class MapperModule
    {
        #region Properties

        private MapperConfig Config { get; set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public MapperContext Context { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => Context.ConfigSettings);
        }

        /// <summary>
        /// Инициализировать конфигурацию.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void InitConfig(Environment environment)
        {
            Config = new MapperConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(MapperExternals externals)
        {
            Context = new MapperContext(Config.Settings, externals);

            Config = null;
        }

        #endregion Public methods
    }
}
