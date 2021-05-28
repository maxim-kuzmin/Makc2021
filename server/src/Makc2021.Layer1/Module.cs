// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Converting;
using Makc2021.Layer1.Query;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Makc2021.Layer1
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
            services.AddSingleton<ICommonResource>(x => new CommonResource(
                x.GetRequiredService<IStringLocalizer<CommonResource>>()
                ));

            services.AddSingleton<IConvertingResource>(x => new ConvertingResource(
                x.GetRequiredService<IStringLocalizer<ConvertingResource>>()
                ));

            services.AddSingleton<IQueryResource>(x => new QueryResource(
                x.GetRequiredService<IStringLocalizer<QueryResource>>()
                ));
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(ICommonResource),
                typeof(IConvertingResource),
                typeof(IQueryResource)
            };
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<Type> GetImports()
        {
            return Enumerable.Empty<Type>();
        }

        #endregion Protected methods
    }
}
