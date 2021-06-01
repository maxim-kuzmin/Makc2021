// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;
using Makc2021.Layer1.Completion;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer5.Apps.Server
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
        /// <param name="appSampleMapperService">Сервис сопоставителя базы данных "Sample".</param>
        public static void Configure(
            Layer3.Sample.Mappers.EF.IMapperService appSampleMapperService
            )
        {
            appSampleMapperService.MigrateDatabase().ConfigureAwaitWithCultureSaving(false).GetResult();

            appSampleMapperService.SeedTestData().ConfigureAwaitWithCultureSaving(false).GetResult();
        }

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            CommonConfigurator.ConfigureServices(services, new CommonModule[]
            {
                new Layer1.Module(),
                new Layer2.Module(),
                new Layer2.Clients.SqlServer.ClientModule(),
                new Layer3.Sample.Clients.SqlServer.EF.ClientModule(),
                new Layer3.Sample.Mappers.EF.MapperModule(),
                new Layer4.Domains.DummyMain.DomainModule(),
                new Module()
            });
        }

        #endregion Public methods
    }
}
