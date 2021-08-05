// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Testing.Fakes.Logging.States;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Testing.Fakes.Logging
{
    /// <summary>
    /// Подделка сервиса логирования.
    /// </summary>
    /// <typeparam name="TCategoryName">Тип имени категории.</typeparam>
    public class LoggingServiceFake<TCategoryName> : ILogger<TCategoryName>
    {
        #region Constants

        /// <summary>
        /// Префикс "Fake".
        /// </summary>
        public const string PREFIX_Fake = "Fake";

        #endregion Constants

        #region Properties

        private LoggingScopeFake Scope { get; } = new LoggingScopeFake();

        /// <summary>
        /// Запись журнала.
        /// </summary>
        public LoggingLogEntryFake LogEntry { get; private set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public IDisposable BeginScope<TState>(TState state)
        {
            if (state is Dictionary<string, object> allowedState)
            {
                return Scope.Push(allowedState);
            }

            throw new NotSupportedException($"Аргумент {nameof(state)} должен иметь тип {typeof(Dictionary<string, object>).Name}");
        }

        /// <inheritdoc/>
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        /// <inheritdoc/>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                return;
            }

            Dictionary<string, object> loggerState = Scope.Peek();

            var logEntry = CreateLogEntryFromLoggerState(loggerState);

            logEntry.CategoryName = typeof(TCategoryName).Name;
            logEntry.Level = logLevel;
            logEntry.Exception = exception;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var logState = (IReadOnlyCollection<KeyValuePair<string, object>>)state;
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            string logMessage = formatter.Invoke(state, exception);

            if (string.IsNullOrWhiteSpace(logEntry.Message) && !string.IsNullOrWhiteSpace(logMessage) && logMessage != "[null]")
            {
                logEntry.Message = logMessage;
            }

            LogEntry = logEntry;
        }

        #endregion Public methods

        #region Private methods

        private static LoggingLogEntryFake CreateLogEntryFromLoggerState(Dictionary<string, object> loggerState)
        {
            var result = new LoggingLogEntryFake();

            FillLogEntryFromBaseState(result, loggerState, new BaseLoggingStateFake(PREFIX_Fake));

            return result;
        }

        private static void FillLogEntryFromBaseState(
            LoggingLogEntryFake logEntry,
            Dictionary<string, object> loggerState,
            params BaseLoggingStateFake[] states
            )
        {
            foreach (var state in states)
            {
                if (state.LoadLoggerState(loggerState))
                {
                    logEntry.Message = state.Message;

                    break;
                }
            }
        }

        #endregion Private methods
    }
}
