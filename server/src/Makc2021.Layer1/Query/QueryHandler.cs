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
    public abstract class QueryHandler
    {
        #region Properties

        private string QueryName { get; }

        /// <summary>
        /// Ресурс ошибок.
        /// </summary>
        protected IErrorsResource AppErrorsResource { get; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger ExtLogger { get; }

        /// <summary>
        /// Функция получения сообщений об ошибках.
        /// </summary>
        public Func<Exception, IEnumerable<string>> FunctionToGetErrorMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="queryName">Имя запроса.</param>
        /// <param name="appErrorsResource">Ресурс ошибок.</param>
        /// <param name="extLogger">Регистратор.</param>
        public QueryHandler(string queryName, IErrorsResource appErrorsResource, ILogger extLogger)
        {
            QueryName = queryName;
            AppErrorsResource = appErrorsResource;
            ExtLogger = extLogger;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Обработать ошибку запроса.
        /// </summary>
        /// <param name="exception">Исключение.</param>
        public void OnError(Exception exception)
        {
            var queryResult = GetQueryResult();

            queryResult.IsOk = false;

            string errorMessage = null;

            var errorMessages = GetErrorMessages(exception);

            if (errorMessages != null && errorMessages.Any())
            {
                queryResult.ErrorMessages.AddRange(errorMessages);
            }
            else
            {
                var error = new Error(exception, AppErrorsResource);

                errorMessage = error.CreateMessageWithCode();

                queryResult.ErrorMessages.Add(errorMessage);
            }

            if (ExtLogger != null)
            {
                if (errorMessage == null && errorMessages != null && errorMessages.Any())
                {
                    errorMessage = string.Join(". ", errorMessages);
                }

                ExtLogger.LogError(exception, $"{QueryName}. {errorMessage}");
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Сделать в начале запроса.
        /// </summary>
        protected virtual void DoOnStart()
        {
#if TEST || DEBUG
            LogQueryInputOnTestOrDebug();
#endif
        }

        /// <summary>
        /// Сделать в случае успешного выполнения запроса.
        /// </summary>
        /// <param name="functionToGetSuccessMessages">Функция получения сообщений об успехах.</param>
        /// <param name="functionToGetWarningMessages">Функция получения сообщений о предупреждениях.</param>
        protected void DoOnSuccess(
            Func<IEnumerable<string>> functionToGetSuccessMessages,
            Func<IEnumerable<string>> functionToGetWarningMessages
            )
        {
            var queryResult = GetQueryResult();

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
            LogQueryResultOnTestOrDebug();
#endif
        }

        /// <summary>
        /// Получить сообщения об ошибках на недействительный ввод запроса.
        /// </summary>
        /// <param name="exception">Исключение.</param>
        /// <returns>Сообщения об ошибках.</returns>
        protected IEnumerable<string> GetErrorMessagesOnInvalidQueryInput(Exception exception)
        {
            if (exception is InvalidPropertiesException ex)
            {
                var ivalidProperties = ex.InvalidProperties;

                return new[]
                {
                    AppErrorsResource.GetForIvalidQueryInput(ivalidProperties)
                };
            }

            return null;
        }

        /// <summary>
        /// Получить входные данные запроса.
        /// </summary>
        /// <returns>Входные данные запроса.</returns>
        protected abstract object GetQueryInput();

        /// <summary>
        /// Получить результат выполнения запроса.
        /// </summary>
        /// <returns>Результат выполнения запроса.</returns>
        protected abstract QueryResult GetQueryResult();

        #endregion Protected methods

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

        private void LogQueryInputOnTestOrDebug()
        {
            if (ExtLogger == null)
            {
                return;
            }

            object queryInput = GetQueryInput();

            string msg = null;

            if (queryInput != null)
            {
                msg = queryInput.SerializeToJson(JsonSerialization.OptionsForLogger);
            }

            msg = !string.IsNullOrEmpty(msg) ? $". Input: {msg}" : string.Empty;

            ExtLogger.LogDebug($"{QueryName}{msg}");
        }

        private void LogQueryResultOnTestOrDebug()
        {
            if (ExtLogger == null)
            {
                return;
            }    
            
            string msg = GetQueryResult().SerializeToJson(JsonSerialization.OptionsForLogger);

            ExtLogger.LogDebug($"{QueryName}. Result: {msg}");
        }

        #endregion Private methods
    }
}
