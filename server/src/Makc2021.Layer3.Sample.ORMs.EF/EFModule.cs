﻿//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.ORMs.EF
{
    using Makc2021.Layer1;

    /// <summary>
    /// ORM "Entity Framework". Модуль.
    /// </summary>
    public class EFModule
    {
        #region Properties

        private EFConfig Config { get; set; }

        /// <summary>
        /// Контекст.
        /// </summary>
        public EFContext Context { get; private set; }

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
            Config = new EFConfig(environment);
        }

        /// <summary>
        /// Инициализировать контекст.
        /// </summary>
        /// <param name="externals">Внешнее.</param>
        public void InitContext(EFExternals externals)
        {
            Context = new EFContext(Config.Settings, externals);

            Config = null;
        }

        #endregion Public methods
    }
}
