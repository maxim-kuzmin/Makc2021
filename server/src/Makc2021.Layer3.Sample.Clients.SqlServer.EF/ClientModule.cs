// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Db;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Entities;
using Makc2021.Layer3.Sample.Entities;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF
{
    /// <summary>
    /// Модуль клиента.
    /// </summary>
    public class ClientModule : CommonModule
    {
        #region Constructors

        /// <inheritdoc/>
        public ClientModule(HashSet<Type> imports)
            : base(imports)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            ThrowExceptionIfTypeIsNotImported(typeof(CommonEnvironment));

            services.AddSingleton(x => new ClientConfig(x.GetRequiredService<CommonEnvironment>()).Settings);

            services.AddSingleton(x => ClientEntitiesSettings.Instance);

            services.AddSingleton<IMapperDbFactory>(x => new ClientDbFactory(
                x.GetRequiredService<IClientConfigSettings>().ConnectionString,
                x.GetRequiredService<EntitiesSettings>(),
                x.GetRequiredService<CommonEnvironment>()
                ));
        }

        /// <summary>
        /// Получить экспортируемые типы.
        /// </summary>
        /// <returns>Экспортируемые типы.</returns>
        public static IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IClientConfigSettings),
                typeof(EntitiesSettings),
                typeof(IMapperDbFactory)
            };
        }

        #endregion Public methods
    }
}
