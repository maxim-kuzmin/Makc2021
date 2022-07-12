// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.IO;
using Makc2021.Layer1.Common;

namespace Makc2021.Layer2.Sql.Clients.Oracle.Config
{
    /// <summary>
    /// Конфигурация клиента.
    /// </summary>
    internal class ClientConfigSource
    {
        #region Properties

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public static string FilePath { get; } = Path.Combine("ConfigFiles", "Layer2.Sql.Clients.Oracle.config");

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
        public ClientConfigSource(CommonEnvironment environment)
        {
            Settings = ClientConfigSettings.Create(FilePath, environment);
        }

        #endregion Constructors
    }
}
