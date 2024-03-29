﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.IO;
using Makc2021.Layer1.Serialization.Json;
using Microsoft.Extensions.Configuration;

namespace Makc2021.Layer1.Common.Config.Json
{
    /// <summary>
    /// Поставщик конфигурации JSON.
    /// </summary>
    /// <typeparam name="TSettings">Тип настроек.</typeparam>
    public class JsonCommonConfigProvider<TSettings> : CommonConfigProvider<TSettings>
    {
        #region Properties

        private CommonEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public JsonCommonConfigProvider(TSettings settings, string filePath, CommonEnvironment environment)
            : base(settings)
        {
            FilePath = filePath;
            Environment = environment;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Load()
        {
            ConfigurationBuilder configurationBuilder = new();

            bool isAbsolutePath = FilePath.StartsWith(
                Environment.BasePath,
                StringComparison.InvariantCultureIgnoreCase
                );

            string absolutePathToFile = isAbsolutePath
                ? FilePath
                : Path.Combine(Environment.BasePath, FilePath);

            bool isPathToFileWithExtension = FilePath.EndsWith(
                ".json",
                StringComparison.InvariantCultureIgnoreCase
                );

            if (isPathToFileWithExtension)
            {
                configurationBuilder.AddJsonFile(absolutePathToFile);
            }
            else
            {
                configurationBuilder.AddConfigFromJsonFile(absolutePathToFile, Environment.Name);
            }

            configurationBuilder.AddEnvironmentVariables().Build().Bind(Settings);
        }

        /// <inheritdoc/>
        public sealed override void Save()
        {
            string json = Settings.SerializeToJson(JsonSerializationOptions.ForConfig);

            File.WriteAllText(FilePath, json);
        }

        #endregion Public methods
    }
}
