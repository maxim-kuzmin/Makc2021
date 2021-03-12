// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer2.Clients.SqlServer
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
        public ClientContext Context { get; } = new();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Provider);
        }

        #endregion Public methods

        #region Private methods

        private ClientContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<ClientContext>();
        }

        #endregion Private methods
    }
}