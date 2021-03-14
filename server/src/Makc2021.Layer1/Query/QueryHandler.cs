// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Makc2021.Layer1.Extensions;
using Makc2021.Layer1.Query.Exceptions;
using Makc2021.Layer1.Resources.Errors;
using Makc2021.Layer1.Serializations;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Обработчик запроса.
    /// </summary>
    public class QueryHandler
    {
        #region Properties

        /// <summary>
        /// Функция получения сообщений об ошибках.
        /// </summary>
        public Func<Exception, IEnumerable<string>> FunctionToGetErrorMessages { get; set; }

        /// <summary>
        /// Ресурс ошибок.
        /// </summary>
        public IErrorsResource ResourceOfErrors { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public QueryHandler(IErrorsResource resourceOfErrors)
        {
            ResourceOfErrors = resourceOfErrors;
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Сделать в случае успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="queryResult">Результат запроса.</param>
        /// <param name="functionToGetSuccessMessages">Функция получения сообщений об успехах.</param>
        /// <param name="functionToGetWarningMessages">Функция получения сообщений о предупреждениях.</param>
        protected void DoOnSuccess(
            ILogger logger,
            QueryResult queryResult,
            Func<IEnumerable<string>> functionToGetSuccessMessages,
            Func<IEnumerable<string>> functionToGetWarningMessages
            )
        {
            queryResult.IsOk = true;

            if (functionToGetSuccessMessages != null)
            {
                var messages = functionToGetSuccessMessages();

                if (messages != null && messages.Any())
                {
                    queryResult.SuccessMessages.AddRange(messages);
                }
            }

            if (functionToGetWarningMessages != null)
            {
                var messages = functionToGetWarningMessages();

                if (messages != null && messages.Any())
                {
                    queryResult.WarningMessages.AddRange(messages);
                }
            }

#if TEST || DEBUG
            LogResultOnTestOrDebug(logger, queryResult);
#endif        
        }

        #endregion Protected methods

        #region Public methods

        /// <summary>
        /// Обработать событие возникновения ошибки.
        /// </summary>
        /// <param name="exception">Исключение.</param>
        /// <param name="logger">Регистратор.</param>
        /// <param name="queryResult">Результат запроса.</param>
        public void OnError(Exception exception, ILogger logger, QueryResult queryResult)
        {
            string errorMessage = null;

            var errorMessages = GetErrorMessages(exception);

            if (errorMessages != null && errorMessages.Any())
            {
                queryResult.ErrorMessages.AddRange(errorMessages);
            }
            else
            {
                var error = new Error(exception, ResourceOfErrors);

                errorMessage = error.CreateMessageWithCode();

                queryResult.ErrorMessages.Add(errorMessage);
            }

            if (logger != null)
            {
                if (errorMessage == null && errorMessages != null && errorMessages.Any())
                {
                    errorMessage = string.Join(". ", errorMessages);
                }

                logger.LogError(exception, errorMessage);
            }
        }

        #endregion Public methods

        #region Private methods

        private IEnumerable<string> GetErrorMessages(Exception exception)
        {
            IEnumerable<string> errorMessages = null;

            if (FunctionToGetErrorMessages != null)
            {
                errorMessages = FunctionToGetErrorMessages.Invoke(exception);
            }

            if (errorMessages == null || !errorMessages.Any())
            {
                string errorMessage = null;

                if (exception is LocalizedException)
                {
                    errorMessage = exception.Message;
                }

                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    errorMessages = new[] { errorMessage };
                }
            }

            return errorMessages;
        }

        private void LogResultOnTestOrDebug(ILogger logger, QueryResult queryResult)
        {
            if (logger != null)
            {
                string msg = queryResult.SerializeToJson(JsonSerialization.OptionsForLogger);

                logger.LogDebug(msg);
            }
        }

        #endregion Private methods
    }
}
