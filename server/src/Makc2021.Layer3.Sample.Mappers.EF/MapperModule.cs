// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sample.Mappers.EF.Config;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Модуль сопоставителя.
    /// </summary>
    public class MapperModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(x => new MapperConfig(x.GetRequiredService<CommonEnvironment>()).Settings);

            services.AddTransient<IMapperService>(x => new MapperService(
                x.GetRequiredService<IMapperConfigSettings>(),
                x.GetRequiredService<IMapperDbFactory>()
                ));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IMapperConfigSettings),
                typeof(IMapperService)
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
                typeof(IMapperDbFactory)
            };
        }

        #endregion Protected methods
    }
}
