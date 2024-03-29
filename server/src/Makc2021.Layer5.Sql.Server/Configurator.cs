﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;
using Makc2021.Layer1.Completion;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer5.Sql.Server
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
        /// <param name="mapperServiceForSample">Сервис сопоставителя для "Sample".</param>
        /// <param name="oracleClientService">Сервис клиента СУБД Oracle.</param>
        public static void Configure(
            Layer3.Sql.Sample.Mappers.EF.IMapperService mapperServiceForSample/*,
            Layer2.Sql.Clients.Oracle.IClientService oracleClientService*/
            )
        {
            //oracleClientService.Configure();

            mapperServiceForSample.MigrateDatabase().ConfigureAwaitWithCultureSaving(false).GetResult();

            mapperServiceForSample.SeedTestData().ConfigureAwaitWithCultureSaving(false).GetResult();
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
                new Layer2.Sql.Module(),
                //new Layer2.Sql.Clients.Oracle.ClientModule(),
                new Layer2.Sql.Clients.SqlServer.ClientModule(),
                new Layer3.Sql.Sample.Clients.SqlServer.ClientModule(),
                new Layer3.Sql.Sample.Clients.SqlServer.EF.ClientModule(),
                new Layer3.Sql.Sample.Mappers.EF.MapperModule(),
                new Layer4.Sql.Domains.DummyMain.DomainModule(),
                new Module()
            });
        }

        #endregion Public methods
    }
}
