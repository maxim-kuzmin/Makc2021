// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer5.GrpcClient.Config;
using Makc2021.Layer5.GrpcServer.Protos.Pages.DummyMain.Item;
using Makc2021.Layer5.GrpcServer.Protos.Pages.DummyMain.List;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer5.GrpcClient
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
            services.AddSingleton(new CommonEnvironment());

            services.AddLocalization(options =>
            {
                CommonConfigurator.ConfigureLocalization(options);
            });

            services.AddSingleton(x => new ConfigSource(x.GetRequiredService<CommonEnvironment>()).Settings);

            services.AddGrpcClient<DummyMainItemPage.DummyMainItemPageClient>((serviceProvider, options) =>
            {
                options.Address = new Uri(serviceProvider.GetRequiredService<IConfigSettings>().ServerUrl);
            });

            services.AddGrpcClient<DummyMainListPage.DummyMainListPageClient>((serviceProvider, options) =>
            {
                options.Address = new Uri(serviceProvider.GetRequiredService<IConfigSettings>().ServerUrl);
            });
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(CommonEnvironment),                
                typeof(DummyMainItemPage.DummyMainItemPageClient),
                typeof(DummyMainListPage.DummyMainListPageClient),
                typeof(IConfigSettings),
                typeof(ILogger),
                typeof(IStringLocalizer)
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
