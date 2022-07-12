// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer4.Sql.Domains.DummyMain.Testing.Fakes;
using Makc2021.Layer4.Sql.Domains.DummyMain.Testing.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Testing
{
    /// <summary>
    /// Модуль.
    /// </summary>
    public class Module : CommonModule
    {
        #region Properties

        private FakesModule Fakes { get; } = new FakesModule();

        private FixturesModule Fixtures { get; } = new FixturesModule();

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            Fakes.ConfigureServices(services);
            Fixtures.ConfigureServices(services);

            services.AddSingleton(new CommonEnvironment());

            services.AddLocalization(options =>
            {
                CommonConfigurator.ConfigureLocalization(options);
            });
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(CommonEnvironment),                
                typeof(ILogger),
                typeof(IStringLocalizer)                
            };
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<CommonModule> GetDependencies()
        {
            return CreateDepedensies(Fakes, Fixtures);
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
