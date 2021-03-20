﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Exceptions;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Makc2021.Layer1.Common
{
    /// <summary>
    /// Общий модуль.
    /// </summary>
    public abstract class CommonModule
    {
        #region Fields

        private readonly HashSet<Type> _imports;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="imports">Импортируемые типы.</param>
        public CommonModule(HashSet<Type> imports)
        {
            _imports = imports;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public abstract void ConfigureServices(IServiceCollection services);

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Инициализировать опции локализации.
        /// </summary>
        /// <param name="options">Опции.</param>
        protected void InitLocalizationOptions(LocalizationOptions options)
        {
            options.ResourcesPath = "ResourceFiles";
        }

        /// <summary>
        /// Выбросить исключение, если тип не импортирован.
        /// </summary>
        /// <param name="type">Тип.</param>
        protected void ThrowExceptionIfTypeIsNotImported(Type type)
        {
            if (_imports.Contains(type))
            {
                return;
            }

            var localizationOptions = new LocalizationOptions();

            InitLocalizationOptions(localizationOptions);

            var options = Options.Create(localizationOptions);

            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);

            var localizer = new StringLocalizer<ErrorsResource>(factory);

            var resource = new ErrorsResource(localizer);

            throw new TypeIsNotImportedException(resource, type);
        }

        #endregion Protected methods
    }
}