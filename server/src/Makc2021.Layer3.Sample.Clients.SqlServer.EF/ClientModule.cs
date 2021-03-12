// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF
{
    /// <summary>
    /// Модуль клиента.
    /// </summary>
    public class ClientModule
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public ClientContext Context { get; private set; }

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
        /// Инициализировать.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public void Init(Environment environment)
        {
            ClientConfig config = new(environment);

            Context = new(config.Settings, environment);
        }

        #endregion Public methods
    }
}
