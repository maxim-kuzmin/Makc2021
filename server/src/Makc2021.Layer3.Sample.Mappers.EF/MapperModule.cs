// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Модуль ORM.
    /// </summary>
    public class MapperModule
    {
        #region Properties

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
        /// Инициализировать.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void Init(Environment environment)
        {
            MapperConfig config = new (environment);

            Context = new MapperContext(config.Settings);
        }

        #endregion Public methods
    }
}
