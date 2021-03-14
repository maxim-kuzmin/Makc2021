// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1;
using Microsoft.Extensions.DependencyInjection;
using SampleClient = Makc2021.Layer3.Sample.Clients.SqlServer.EF;
using SampleMapper = Makc2021.Layer3.Sample.Mappers.EF;

namespace Makc2021.Layer5.Apps.WebAPI
{
    /// <summary>
    /// Модуль приложения.
    /// </summary>
    public class AppModule
    {
        #region Properties

        /// <summary>
        /// Клиент "Sample".
        /// </summary>
        public SampleClient::ClientModule SampleClient { get; } = new()
        {
            IsEnvironmentReady = true
        };

        /// <summary>
        /// Сопоставитель "Sample".
        /// </summary>
        public SampleMapper::MapperModule SampleMapper { get; } = new()
        {
            IsEnvironmentReady = true
        };

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
            services.AddSingleton(new Environment());

            SampleClient.ConfigureServices(services);
            SampleMapper.ConfigureServices(services);            
        }

        #endregion Public methods
    }
}
