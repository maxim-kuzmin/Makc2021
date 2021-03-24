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
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(x => new ClientConfig(x.GetRequiredService<CommonEnvironment>()).Settings);

            services.AddSingleton(x => ClientEntitiesSettings.Instance);

            services.AddSingleton<IMapperDbFactory>(x => new ClientDbFactory(
                x.GetRequiredService<IClientConfigSettings>().ConnectionString,
                x.GetRequiredService<EntitiesSettings>(),
                x.GetRequiredService<CommonEnvironment>()
                ));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IClientConfigSettings),
                typeof(EntitiesSettings),
                typeof(IMapperDbFactory)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(CommonEnvironment)
            };
        }

        #endregion Protected methods
    }
}
