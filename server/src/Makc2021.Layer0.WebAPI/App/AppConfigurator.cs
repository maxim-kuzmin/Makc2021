﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

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

            Module.SampleMapper.InitContext();
        }

        private void InitConfigs()
        {
            Module.SampleMapper.InitConfig(Environment);
            Module.SampleClient.InitConfig(Environment);
        }

        #endregion Private methods
    }
}
