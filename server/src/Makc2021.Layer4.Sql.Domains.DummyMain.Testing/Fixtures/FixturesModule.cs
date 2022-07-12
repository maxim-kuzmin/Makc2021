// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Testing.Fixtures
{
    /// <summary>
    /// Модуль оснасток.
    /// </summary>
    public class FixturesModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => new DomainServiceFixture(
                x.GetRequiredService<IMapperDbFactory>()
                ));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(DomainServiceFixture)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<Type> GetImports()
        {
            return new[]
            {
                typeof(IMapperDbFactory)
            };
        }

        #endregion Protected methods
    }
}
