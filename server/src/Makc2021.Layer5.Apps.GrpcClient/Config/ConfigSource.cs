// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.IO;
using Makc2021.Layer1.Common;

namespace Makc2021.Layer5.Apps.GrpcClient.Config
{
    /// <summary>
    /// Источник конфигурации.
    /// </summary>
    internal class ConfigSource
    {
        #region Properties

        /// <summary>
        /// Путь к файлу.
        /// </summary>
        public static string FilePath { get; } = Path.Combine("ConfigFiles", "Makc2021.Layer5.Apps.GrpcClient.config");

        /// <summary>
        /// Настройки.
        /// </summary>
        public IConfigSettings Settings { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public ConfigSource(CommonEnvironment environment)
        {
            Settings = ConfigSettings.Create(FilePath, environment);
        }

        #endregion Constructors
    }
}
