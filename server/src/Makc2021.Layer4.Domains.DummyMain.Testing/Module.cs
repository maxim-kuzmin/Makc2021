// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Moq;

namespace Makc2021.Layer4.Domains.DummyMain.Testing
{
    /// <summary>
    /// Модуль.
    /// </summary>
    public class Module : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new CommonEnvironment());

            services.AddLocalization(options =>
            {
                CommonConfigurator.ConfigureLocalization(options);
            });

            services.AddSingleton(x => CreateDbFactory());
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(CommonEnvironment),                
                typeof(ILogger),
                typeof(IMapperDbFactory),
                typeof(IStringLocalizer)                
            };
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

        #region Private methods

        private IMapperDbFactory CreateDbFactory()
        {
            var result = new Mock<IMapperDbFactory>();

            return result.Object;
        }

        #endregion Private methods
    }
}
