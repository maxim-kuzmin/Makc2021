// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makc2021.Layer1.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer4.Domains.DummyMain.Testing
{
    /// <summary>
    /// Конфигуратор.
    /// </summary>
    public static class Configurator
    {
        #region Properties

        /// <summary>
        /// Поставщик сервисов.
        /// </summary>
        public static ServiceProvider ServiceProvider { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Использовать сервисы.
        /// </summary>
        public static void UseServices()
        {
            var services = new ServiceCollection();

            CommonConfigurator.ConfigureServices(services, new CommonModule[]
            {
                new DomainModule(),
                new Module()
            });

            ServiceProvider = services.BuildServiceProvider();
        }

        #endregion Public methods
    }
}