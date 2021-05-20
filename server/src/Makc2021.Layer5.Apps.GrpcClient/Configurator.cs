// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer5.Apps.GrpcClient
{
    /// <summary>
    /// Конфигуратор.
    /// </summary>
    public static class Configurator
    {
        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        public static void Configure()
        {
        }

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            CommonConfigurator.ConfigureServices(services, new CommonModule[]
                {
                    new Module()
                });
        }

        #endregion Public methods
    }
}
