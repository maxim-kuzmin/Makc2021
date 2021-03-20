// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sample.Mappers.EF.Config;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Модуль сопоставителя.
    /// </summary>
    public class MapperModule : CommonModule
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperModule(HashSet<Type> imports)
            : base(imports)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            ThrowExceptionIfTypeIsNotImported(typeof(Layer1.Environment));

            services.AddSingleton(x => new MapperConfig(x.GetRequiredService<Layer1.Environment>()).Settings);

            ThrowExceptionIfTypeIsNotImported(typeof(IMapperDbFactory));

            services.AddTransient<IMapperService>(x => new MapperService(
                x.GetRequiredService<IMapperConfigSettings>(),
                x.GetRequiredService<IMapperDbFactory>()
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
                typeof(IMapperConfigSettings),
                typeof(IMapperService)
            };
        }

        #endregion Public methods
    }
}
