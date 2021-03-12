// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1;

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config
{
    /// <summary>
    /// Настройки конфигурации клиента.
    /// </summary>
    public class ClientConfigSettings : IClientConfigSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string ConnectionString { get; set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IClientConfigSettings Create(
            string configFilePath,
            Environment environment
            )
        {
            ClientConfigSettings result = new();

            ClientConfigProvider configProvider = new(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}