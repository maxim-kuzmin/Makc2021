// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.IO;
using NLog;

namespace Makc2021.Layer1.Common.Config.NLog
{
    /// <summary>
    /// Расширение конфигурации NLog.
    /// </summary>
    public static class NLogCommonConfigExtension
    {
        #region Public methods

        /// <summary>
        /// Загрузить конфигурацию из XML-файла.
        /// </summary>
        /// <param name="logFactory">Фабрика логирования.</param>
        /// <param name="absolutePathToFileWithoutExtension">Абсолютный путь к файлу без расширения.</param>
        /// <param name="environmentName">Имя окружения.</param>
        /// <returns>Фабрика логирования.</returns>
        public static LogFactory LoadConfigFromXmlFile(
            this LogFactory logFactory,
            string absolutePathToFileWithoutExtension,
            string environmentName
            )
        {
            const string fileExtension = ".xml";

            string machineName = Environment.MachineName.ToUpper();

            string filePath = $"{absolutePathToFileWithoutExtension}.m.{machineName}{fileExtension}";

            bool isOk = false;

            if (File.Exists(filePath))
            {
                logFactory.LoadConfiguration(filePath);

                isOk = true;
            }

            if (!isOk && !string.IsNullOrWhiteSpace(environmentName))
            {
                filePath = $"{absolutePathToFileWithoutExtension}.{environmentName}{fileExtension}";

                if (File.Exists(filePath))
                {
                    logFactory.LoadConfiguration(filePath);

                    isOk = true;
                }
            }

            if (!isOk)
            {
                filePath = $"{absolutePathToFileWithoutExtension}{fileExtension}";

                if (File.Exists(filePath))
                {
                    logFactory.LoadConfiguration(filePath);

                    isOk = true;
                }
            }

            if (!isOk)
            {
                throw new FileNotFoundException($"NLog configuration file \"{filePath}\" not found");
            }

            return logFactory;
        }

        #endregion Public methods
    }
}
