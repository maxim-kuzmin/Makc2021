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
    public abstract class CommonConfigurator
    {
        #region Fields

        private readonly IEnumerable<CommonModule> _modules;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public CommonConfigurator()
        {
            var exports = Enumerable.Empty<Type>();

            _modules = GetModules();

            foreach (var module in _modules)
            {
                exports = exports.Union(module.GetExports());
            }

            var allExports = exports.ToHashSet();

            var notImportedTypes = Enumerable.Empty<Type>();

            foreach (var module in _modules)
            {
                notImportedTypes = notImportedTypes.Union(module.GetNotImportedtTypes(allExports));
            }

            if (notImportedTypes.Any())
            {
                ThrowExceptionForNotImportedTypes(notImportedTypes);
            }
        }

        #endregion Constructors

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
        public void ConfigureServices(IServiceCollection services)
        {
            foreach (var module in _modules)
            {
                module.ConfigureServices(services);
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Получить модули.
        /// </summary>
        /// <returns>Модули.</returns>
        protected abstract IEnumerable<CommonModule> GetModules();

        #endregion Protected methods

        #region Private methods

        private void ThrowExceptionForNotImportedTypes(IEnumerable<Type> types)
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
