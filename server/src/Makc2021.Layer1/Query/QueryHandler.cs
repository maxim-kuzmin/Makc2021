﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Extensions;
using Makc2021.Layer1.Serializations;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Обработчик запроса.
    /// </summary>
    public abstract class QueryHandler : IQueryHandler
    {
        #region Properties

        private string QueryName { get; }

        /// <summary>
        /// Ресурс запроса.
        /// </summary>
        protected IQueryResource AppQueryResource { get; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger ExtLogger { get; }

        /// <summary>
        /// Функция получения сообщений об ошибках.
        /// </summary>
        protected Func<Exception, IEnumerable<string>> FunctionToGetErrorMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="queryName">Имя запроса.</param>
        /// <param name="appQueryResource">Ресурс запроса.</param>
        /// <param name="extLogger">Регистратор.</param>
        public QueryHandler(string queryName, IQueryResource appQueryResource, ILogger extLogger)
        {
            QueryName = queryName;
            AppQueryResource = appQueryResource;
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

            string errorMessage;

            var errorMessages = GetErrorMessages(exception);

            if (errorMessages != null && errorMessages.Any())
            {
                queryResult.ErrorMessages.AddRange(errorMessages);

                errorMessage = string.Join(". ", errorMessages);
            }
            else
            {
                errorMessage = AppQueryResource.GetErrorMessageForDefault();

                queryResult.ErrorMessages.Add(errorMessage);
            }

            if (ExtLogger != null)
            {
                return;
            }

            queryResult.ErrorCode = Guid.NewGuid().ToString("N").ToUpper();

            errorMessage = AppQueryResource.GetErrorMessageWithCode(errorMessage, queryResult.ErrorCode);

            ExtLogger.LogError(exception, $"{QueryName}. {errorMessage}");
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

                if (exception is CommonException)
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

            string value = null;

            if (queryInput != null)
            {
                value = queryInput.SerializeToJson(JsonSerialization.OptionsForLogger);
            }

            string title = AppQueryResource.GetTitleForInput();

            value = !string.IsNullOrEmpty(value) ? $". {title}: {value}" : string.Empty;

            ExtLogger.LogDebug($"{QueryName}{value}");
        }

        private void LogQueryResultOnTestOrDebug()
        {
            if (ExtLogger == null)
            {
                return;
            }

            string title = AppQueryResource.GetTitleForResult();

            string value = GetQueryResult().SerializeToJson(JsonSerialization.OptionsForLogger);

            ExtLogger.LogDebug($"{QueryName}. {title}: {value}");
        }

        #endregion Private methods
    }
}
