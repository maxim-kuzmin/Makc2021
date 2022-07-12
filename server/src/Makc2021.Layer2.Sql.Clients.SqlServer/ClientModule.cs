// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer2.Sql.Clients.SqlServer
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
            services.AddSingleton<IClientProvider>(x => new ClientProvider());
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IClientProvider)
            };
        }

        #endregion Public methods
    }
}