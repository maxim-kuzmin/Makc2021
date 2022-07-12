// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sql.Sample.Clients.SqlServer.Config;
using Makc2021.Layer3.Sql.Sample.Clients.SqlServer.EF.Db;
using Makc2021.Layer3.Sql.Sample.Entities;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer3.Sql.Sample.Clients.SqlServer.EF
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
            services.AddSingleton<IMapperDbFactory>(x => new ClientDbFactory(
                x.GetRequiredService<IClientConfigSettings>(),
                x.GetRequiredService<Layer2.Sql.Config.IConfigSettings>(),
                x.GetRequiredService<EntitiesSettings>(),
                x.GetRequiredService<CommonEnvironment>(),
                x.GetRequiredService<ILogger<ClientDbFactory>>()
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
                typeof(CommonEnvironment),
                typeof(ILogger),
                typeof(Layer2.Sql.Config.IConfigSettings)
            };
        }

        #endregion Protected methods
    }
}
