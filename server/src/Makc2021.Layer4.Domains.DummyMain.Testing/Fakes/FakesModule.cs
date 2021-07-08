// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Makc2021.Layer4.Domains.DummyMain.Testing.Fakes
{
    /// <summary>
    /// Модуль подделок.
    /// </summary>
    public class FakesModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => CreateDbFactory());
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IMapperDbFactory)
            };
        }

        #endregion Public methods

        #region Private methods

        private static IMapperDbFactory CreateDbFactory()
        {
            var result = new Mock<IMapperDbFactory>();

            return result.Object;
        }

        #endregion Private methods
    }
}
