﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Configuration;

namespace Makc2021.Layer1.Common.Config.Json
{
    using System;

    /// <summary>
    /// Расширение конфигурации JSON.
    /// </summary>
    public static class JsonCommonConfigExtension
    {
        #region Public methods

        /// <summary>
        /// Добавить конфигурацию из JSON-файла.
        /// </summary>
        /// <param name="builder">Построитель конфигурации.</param>
        /// <param name="absolutePathToFileWithoutExtension">Абсолютный путь к файлу без расширения.</param>
        /// <param name="environmentName">Имя окружения.</param>
        /// <returns>Построитель конфигурации.</returns>
        public static IConfigurationBuilder AddConfigFromJsonFile(
            this IConfigurationBuilder builder,
            string absolutePathToFileWithoutExtension,
            string environmentName = null
            )
        {
            const string fileExtension = ".json";

            builder.AddJsonFile(
                $"{absolutePathToFileWithoutExtension}{fileExtension}",
                false,
                true
                );

            if (!string.IsNullOrWhiteSpace(environmentName))
            {
                builder.AddJsonFile(
                    $"{absolutePathToFileWithoutExtension}.{environmentName}{fileExtension}",
                    true,
                    true
                    );
            }

            string machineName = Environment.MachineName.ToUpper();

            builder.AddJsonFile(
                $"{absolutePathToFileWithoutExtension}.m.{machineName}{fileExtension}",
                true,
                true
                );

            return builder;
        }

        #endregion Public methods
    }
}
