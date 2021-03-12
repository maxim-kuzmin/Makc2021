// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1;
using Makc2021.Layer1.Exceptions;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Db;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
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
        /// Признак готовности окружения.
        /// </summary>
        public bool IsEnvironmentReady { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            if (!IsEnvironmentReady)
            {
                throw new TypeIsNotReadyException(typeof(Environment));
            }

            services.AddSingleton(x => new ClientConfig(x.GetRequiredService<Environment>()).Settings);

            services.AddSingleton(x => ClientEntitiesSettings.Instance);

            services.AddSingleton<IMapperDbFactory>(x => new ClientDbFactory(
                x.GetRequiredService<IClientConfigSettings>().ConnectionString,
                x.GetRequiredService<EntitiesSettings>(),
                x.GetRequiredService<Environment>()
                ));
        }

        #endregion Public methods
    }
}
