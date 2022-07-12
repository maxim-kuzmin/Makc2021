// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Makc2021.Layer2.Sql.Config
{
    /// <summary>
    /// Интерфейс настроек конфигурации.
    /// </summary>
    public interface IConfigSettings
    {
        #region Properties

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        int DbCommandTimeout { get; }

        /// <summary>
        /// Уровень логирования.
        /// </summary>
        LogLevel LogLevel { get; }

        #endregion Properties
    }
}