// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoFixture;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Testing;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Testing.Fakes.Queries.Item.Get
{
    /// <summary>
    /// Модуль подделок запроса на получение элемента в домене.
    /// </summary>
    public class DomainItemGetQueryFakesModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {           
            services.AddTransient(x => new DomainItemGetQueryHandlerFake());
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(DomainItemGetQueryHandlerFake)    
            };
        }

        #endregion Public methods
    }
}
