// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.IO;
using Makc2021.Layer1;
using Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config;

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF
{
    /// <summary>
    /// Конфигурация клиента.
    /// </summary>
    internal class ClientConfig
    {
        #region Properties

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        internal static string FilePath { get; } = Path.Combine("ConfigFiles", "Layer3.Sample.Clients.SqlServer.EF.config");

        /// <summary>
        /// Настройки.
        /// </summary>
        public IClientConfigSettings Settings { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ClientConfig(Environment environment)
        {
            Settings = ClientConfigSettings.Create(FilePath, environment);
        }

        #endregion Constructors
    }
}
