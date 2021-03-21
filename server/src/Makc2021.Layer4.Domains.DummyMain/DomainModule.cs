// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Query;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer4.Domains.DummyMain.Queries.List.Get;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer4.Domains.DummyMain
{
    /// <summary>
    /// Модуль домена.
    /// </summary>
    public class DomainModule : CommonModule
    {
        #region Constructors

        /// <inheritdoc/>
        public DomainModule(HashSet<Type> imports)
            : base(imports)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            ThrowExceptionIfTypeIsNotImported(typeof(IStringLocalizer));

            services.AddSingleton<IDomainResource>(x => new DomainResource(
                x.GetRequiredService<IStringLocalizer<DomainResource>>()
                ));

            ThrowExceptionIfTypeIsNotImported(typeof(Layer3.Sample.Mappers.EF.IMapperService));

            services.AddTransient<IDomainService>(x => new DomainService(
                x.GetRequiredService<Layer3.Sample.Mappers.EF.IMapperService>()
                ));

            ThrowExceptionIfTypeIsNotImported(typeof(ILogger));

            services.AddTransient<IItemGetQueryDomainHandler>(x => new ItemGetQueryDomainHandler(
                x.GetRequiredService<IDomainResource>(),
                x.GetRequiredService<IQueryResource>(),
                x.GetRequiredService<ILogger<ItemGetQueryDomainHandler>>()
                ));

            services.AddTransient<IListGetQueryDomainHandler>(x => new ListGetQueryDomainHandler(
                x.GetRequiredService<IDomainResource>(),
                x.GetRequiredService<IQueryResource>(),
                x.GetRequiredService<ILogger<ListGetQueryDomainHandler>>()
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
                typeof(IDomainResource),
                typeof(IDomainService),
                typeof(IItemGetQueryDomainHandler),
                typeof(IListGetQueryDomainHandler)
            };
        }

        #endregion Public methods
    }
}
