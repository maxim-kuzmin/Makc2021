// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Testing.Fakes.Logging
{
    /// <summary>
    /// Подделка записи журнала логирования.
    /// </summary>
    public class LoggingLogEntryFake
    {
        #region Properties

        /// <summary>
        /// Имя категории.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Исключение.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        public LogLevel Level { get; set; }

        /// <summary>
        /// Сообщение.
        /// </summary>
        public string Message { get; set; }

        #endregion Properties
    }
}
