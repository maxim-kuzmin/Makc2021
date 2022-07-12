// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer2.Sql.Config;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer2.Sql
{
    /// <summary>
    /// Модуль.
    /// </summary>
    public class Module : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(x => new ConfigSource(x.GetRequiredService<CommonEnvironment>()).Settings);
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IConfigSettings)
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
