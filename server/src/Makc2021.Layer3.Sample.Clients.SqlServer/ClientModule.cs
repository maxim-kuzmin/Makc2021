// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sample.Clients.SqlServer.Config;
using Makc2021.Layer3.Sample.Clients.SqlServer.Entities;
using Makc2021.Layer3.Sample.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer3.Sample.Clients.SqlServer
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
            services.AddSingleton(x => new ClientConfigSource(x.GetRequiredService<CommonEnvironment>()).Settings);

            services.AddSingleton(x => ClientEntitiesSettings.Instance); // EntitiesSettings
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IClientConfigSettings),
                typeof(EntitiesSettings)
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
