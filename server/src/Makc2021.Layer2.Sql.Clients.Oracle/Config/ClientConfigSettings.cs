﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;

namespace Makc2021.Layer2.Sql.Clients.Oracle.Config
{
    /// <summary>
    /// Настройки конфигурации клиента.
    /// </summary>
    internal class ClientConfigSettings : IClientConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string TnsAdmin { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        public static IClientConfigSettings Create(string configFilePath, CommonEnvironment environment)
        {
            ClientConfigSettings result = new();

            ClientConfigProvider configProvider = new(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Public methods
    }
}