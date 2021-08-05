// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Testing.Fakes.Logging;
using Makc2021.Layer1.Testing.Fakes.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer1.Testing.Fakes
{
    /// <summary>
    /// Модуль подделок.
    /// </summary>
    public class FakesModule : CommonModule
    {
        #region Properties

        private LoggingFakesModule Logging { get; } = new LoggingFakesModule();

        private QueryFakesModule Query { get; } = new QueryFakesModule();

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            Logging.ConfigureServices(services);
            Query.ConfigureServices(services);
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<CommonModule> GetDependencies()
        {
            return CreateDepedensies(Logging, Query);
        }

        #endregion Public methods
    }
}
