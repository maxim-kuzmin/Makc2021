// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Makc2021.Layer1.Common
{
    /// <summary>
    /// Общий конфигуратор.
    /// </summary>
    public static class CommonConfigurator
    {
        #region Public methods

        /// <summary>
        /// Настроить опции локализации.
        /// </summary>
        /// <param name="options">Опции.</param>
        public static void ConfigureLocalization(LocalizationOptions options)
        {
            options.ResourcesPath = "ResourceFiles";
        }

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="modules">Модули.</param>
        public static void ConfigureServices(IServiceCollection services, IEnumerable<CommonModule> modules)
        {
            var exports = Enumerable.Empty<Type>();

            foreach (var module in modules)
            {
                exports = exports.Union(module.GetExports());
            }

            var allExports = exports.ToHashSet();

            var notImportedTypes = Enumerable.Empty<Type>();

            foreach (var module in modules)
            {
                var notImportedtTypesOfModule = module.GetNotImportedtTypes(allExports);

                if (notImportedtTypesOfModule.Any())
                {
                    notImportedTypes = notImportedTypes.Union(notImportedtTypesOfModule);
                }
            }

            if (notImportedTypes.Any())
            {
                ThrowExceptionForNotImportedTypes(notImportedTypes);
            }

            foreach (var module in modules)
            {
                module.ConfigureServices(services);
            }
        }

        #endregion Public methods

        #region Private methods

        private static void ThrowExceptionForNotImportedTypes(IEnumerable<Type> types)
        {
            var localizationOptions = new LocalizationOptions();

            ConfigureLocalization(localizationOptions);

            var options = Options.Create(localizationOptions);

            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);

            var localizer = new StringLocalizer<CommonResource>(factory);

            var resource = new CommonResource(localizer);

            throw new Exception(resource.GetErrorMessageForNotImportedTypes(types));
        }

        #endregion Private methods
    }
}
