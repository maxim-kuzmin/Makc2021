// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer2.Sql.Common;
using Makc2021.Layer5.Sql.Server.Pages.DummyMain.Item;
using Makc2021.Layer5.Sql.Server.Pages.DummyMain.List;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using IClientProviderForSqlServer = Makc2021.Layer2.Sql.Clients.SqlServer.ClientProvider;
using IDummyMainDomainItemGetQueryHandler = Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get.IDomainItemGetQueryHandler;
using IDummyMainDomainListGetQueryHandler = Makc2021.Layer4.Sql.Domains.DummyMain.Queries.List.Get.IDomainListGetQueryHandler;
using IDummyMainDomainService = Makc2021.Layer4.Sql.Domains.DummyMain.IDomainService;

namespace Makc2021.Layer5.Sql.Server
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

            services.AddLocalization(CommonConfigurator.ConfigureLocalization);

            services.AddSingleton<ICommonProvider>(x => x.GetRequiredService<IClientProviderForSqlServer>());

            services.AddScoped<IDummyMainItemPageService>(x => new DummyMainItemPageService(
                x.GetRequiredService<IDummyMainDomainItemGetQueryHandler>(),
                x.GetRequiredService<IDummyMainDomainService>()
                ));

            services.AddScoped<IDummyMainListPageService>(x => new DummyMainListPageService(
                x.GetRequiredService<IDummyMainDomainListGetQueryHandler>(),
                x.GetRequiredService<IDummyMainDomainService>()
                ));
        }

        /// <inheritdoc/>
        public override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(CommonEnvironment),
                typeof(ICommonProvider),
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
                typeof(IClientProviderForSqlServer),
                typeof(IDummyMainDomainItemGetQueryHandler),
                typeof(IDummyMainDomainListGetQueryHandler),
                typeof(IDummyMainDomainService)
            };
        }

        #endregion Protected methods
    }
}
