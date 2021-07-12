// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer4.Domains.DummyMain;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer4.Domains.DummyMain.Queries.List.Get;
using Makc2021.Layer5.Server.Pages.DummyMain.Item;
using Makc2021.Layer5.Server.Pages.DummyMain.List;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer5.Server
{
    /// <summary>
    /// Модуль.
    /// </summary>
    public class Module : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new CommonEnvironment());

            services.AddLocalization(options =>
            {
                CommonConfigurator.ConfigureLocalization(options);
            });

            services.AddTransient<IDummyMainItemPageService>(x => new DummyMainItemPageService(
                x.GetRequiredService<IDomainItemGetQueryHandler>(),
                x.GetRequiredService<IDomainService>()
                ));

            services.AddTransient<IDummyMainListPageService>(x => new DummyMainListPageService(
                x.GetRequiredService<IDomainListGetQueryHandler>(),
                x.GetRequiredService<IDomainService>()
                ));
        }

        /// <inheritdoc/>
        public override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(CommonEnvironment),
                typeof(IDummyMainItemPageService),
                typeof(IDummyMainListPageService),
                typeof(ILogger),
                typeof(IStringLocalizer)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override IEnumerable<Type> GetImports()
        {
            return new[]
            {                    
                typeof(IDomainItemGetQueryHandler),
                typeof(IDomainListGetQueryHandler),
                typeof(IDomainService)
            };
        }

        #endregion Protected methods
    }
}
