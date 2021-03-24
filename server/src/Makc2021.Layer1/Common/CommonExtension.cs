// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Makc2021.Layer1.Common
{
    public static class CommonExtension
    {
        #region Public methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        /// <param name="options">Опции.</param>
        public static void Init(this LocalizationOptions options)
        {
            options.ResourcesPath = "ResourceFiles";
        }

        /// <summary>
        /// Выбросить исключение для не импортированных типов.
        /// </summary>
        /// <param name="types">Типы.</param>
        /// <param name="resource">Ресурс.</param>
        public static void ThrowExceptionForNotImportedTypes(this IEnumerable<Type> types)
        {
            var localizationOptions = new LocalizationOptions();

            localizationOptions.Init();

            var options = Options.Create(localizationOptions);

            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);

            var localizer = new StringLocalizer<CommonResource>(factory);

            var resource = new CommonResource(localizer);

            throw new Exception(resource.GetErrorMessageForNotImportedTypes(types));
        }

        #endregion Public methods
    }
}
