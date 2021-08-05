// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer1.Testing.Fakes.Logging
{
    /// <summary>
    /// Подделка состояния логирования.
    /// </summary>
    public abstract class LoggingStateFake
    {
        #region Properties

        private string LoggerStatePrefix { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="loggerStatePrefix">Префикс состояния регистратора.</param>
        public LoggingStateFake(string loggerStatePrefix)
        {
            LoggerStatePrefix = loggerStatePrefix;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить ключ состояния регистратора.
        /// Формат ключа: {Префикс состояния регистратора}.{Константа "PREFIX" в подклассе}.{Константа "PROP_Имя свойства" в подклассе}.
        /// </summary>
        /// <param name="propertyName">Имя свойства.</param>
        /// <returns>Ключ состояния регистратора</returns>
        public string CreateLoggerStateKey(string propertyName)
        {
            return $"{LoggerStatePrefix}.{GetPrefix()}.{propertyName}";
        }

        /// <summary>
        /// Заполнить состояние регистратора.
        /// </summary>
        /// <param name="loggerState">Состояние регистратора.</param>
        public abstract void FillLoggerState(Dictionary<string, object> loggerState);

        /// <summary>
        /// Загрузить состояние регистратора.
        /// </summary>
        /// <param name="loggerState">Состояние регистратора.</param>
        /// <returns>Признак успешности загрузки.</returns>
        public abstract bool LoadLoggerState(Dictionary<string, object> loggerState);

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Получить префикс.
        /// </summary>
        /// <returns>Префикс.</returns>
        protected abstract string GetPrefix();

        #endregion Protected methods
    }
}
