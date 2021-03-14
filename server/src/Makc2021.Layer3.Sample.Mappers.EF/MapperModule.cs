// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1;
using Makc2021.Layer1.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Модуль сопоставителя.
    /// </summary>
    public class MapperModule
    {
        #region Properties

        /// <summary>
        /// Признак готовности окружения.
        /// </summary>
        public bool IsEnvironmentReady { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            if (!IsEnvironmentReady)
            {
                throw new TypeIsNotReadyException(typeof(Environment));
            }

            services.AddSingleton(x => new MapperConfig(x.GetRequiredService<Environment>()).Settings);
        }

        #endregion Public methods
    }
}
