﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;

namespace Makc2021.Layer5.Apps.GrpcClient.Config
{
    /// <summary>
    /// Настройки конфигурации.
    /// </summary>
    internal class ConfigSettings : IConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string ServerUrl { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IConfigSettings Create(string configFilePath, CommonEnvironment environment)
        {
            ConfigSettings result = new();

            ConfigProvider configProvider = new(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Public methods
    }
}