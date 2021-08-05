// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer1.Logging;

namespace Makc2021.Layer1.Testing.Fakes.Logging.States
{
    /// <summary>
    /// Подделка базового состояния логирования.
    /// </summary>
    public class BaseLoggingStateFake : LoggingStateFake
    {
        #region Constants

        /// <summary>
        /// Префикс: "Base".
        /// </summary>
        public const string PREFIX = "Base";

        /// <summary>
        /// Свойство "Message".
        /// </summary>
        public const string PROP_Message = "Message";

        #endregion Constants

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="loggerStatePrefix">Префикс состояния регистратора.</param>
        public BaseLoggingStateFake(string loggerStatePrefix)
            : base(loggerStatePrefix)
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Сообщение.
        /// </summary>
        public string Message { get; set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public sealed override void FillLoggerState(Dictionary<string, object> loggerState)
        {
            loggerState[CreateLoggerStateKey(PROP_Message)] = Message;
        }

        /// <inheritdoc/>
        public sealed override bool LoadLoggerState(Dictionary<string, object> loggerState)
        {
            return loggerState.TryLoadLoggerState<string>(CreateLoggerStateKey(PROP_Message), value => Message = value);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override string GetPrefix()
        {
            return PREFIX;
        }

        #endregion Protected methods
    }
}
