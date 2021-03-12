// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

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
        public void InitContext()
        {
            Context = new MapperContext(Config.Settings);

            Config = null;
        }

        #endregion Public methods
    }
}
