// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Testing.Fakes;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer1.Testing
{
    /// <summary>
    /// Модуль.
    /// </summary>
    public class Module : CommonModule
    {
        #region Properties

        private FakesModule Fakes { get; } = new FakesModule();

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {
            Fakes.ConfigureServices(services);
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<CommonModule> GetDependencies()
        {
            return CreateDepedensies(Fakes);
        }

        #endregion Public methods
    }
}
