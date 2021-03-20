// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer4.Domains.DummyMain.Queries.List.Get;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using SampleMapper = Makc2021.Layer3.Sample.Mappers.EF;

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

            services.AddSingleton<IItemGetQueryDomainResource>(x => new ItemGetQueryDomainResource(
                x.GetRequiredService<IStringLocalizer<ItemGetQueryDomainResource>>()
                ));

            services.AddSingleton<IListGetQueryDomainResource>(x => new ListGetQueryDomainResource(
                x.GetRequiredService<IStringLocalizer<ListGetQueryDomainResource>>()
                ));

            ThrowExceptionIfTypeIsNotImported(typeof(SampleMapper::IMapperService));

            services.AddTransient<IDomainService>(x => new DomainService(
                x.GetRequiredService<SampleMapper::IMapperService>()
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
                typeof(IDomainService),
                typeof(IItemGetQueryDomainResource),
                typeof(IListGetQueryDomainResource)
            };
        }

        #endregion Public methods
    }
}
