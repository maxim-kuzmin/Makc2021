﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        #region Constructors

        /// <inheritdoc/>
        public Module(HashSet<Type> imports)
            : base(imports)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            ThrowExceptionIfTypeIsNotImported(typeof(IStringLocalizer));

            services.AddSingleton<IConvertingResource>(x => new ConvertingResource(
                x.GetRequiredService<IStringLocalizer<ConvertingResource>>()
                ));

            services.AddSingleton<ICommonResource>(x => new CommonResource(
                x.GetRequiredService<IStringLocalizer<CommonResource>>()
                ));

            services.AddSingleton<IQueryResource>(x => new QueryResource(
                x.GetRequiredService<IStringLocalizer<QueryResource>>()
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
                typeof(IConvertingResource),
                typeof(ICommonResource),
                typeof(IQueryResource)
            };
        }

        #endregion Public methods
    }
}
