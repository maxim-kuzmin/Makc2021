// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

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

        private string QueryCode { get; }

        private string Title { get; }

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
            QueryCode = Guid.NewGuid().ToString("N").ToUpper();

            string titleForQueryCode = appQueryResource.GetTitleForQueryCode();

            Title = $"{queryName}. {titleForQueryCode}: {QueryCode}. ";

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
            queryResult.QueryCode = QueryCode;

            string errorMessage;

            var errorMessages = GetErrorMessages(exception);

            if (errorMessages != null && errorMessages.Any())
            {
                queryResult.ErrorMessages.AddRange(errorMessages);

                errorMessage = string.Join(". ", errorMessages).Replace("!.", "!").Replace("?.", "?");
            }
            else
            {
                errorMessage = AppQueryResource.GetErrorMessageForDefault();

                queryResult.ErrorMessages.Add(errorMessage);
            }

            if (ExtLogger != null)
            {
                string titleForError = AppQueryResource.GetTitleForError();

                ExtLogger.LogError(exception, $"{Title}{titleForError}. {errorMessage}");
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
            LogStartIfTestOrDebugEnabled();
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
            queryResult.QueryCode = QueryCode;

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
            LogSuccessIfTestOrDebugEnabled();
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

        private void LogStartIfTestOrDebugEnabled()
        {
            if (ExtLogger != null)
            {
                object queryInput = GetQueryInput();

                string titleForStart = AppQueryResource.GetTitleForStart();
                string titleForInput = AppQueryResource.GetTitleForInput();
                string valueForInput = queryInput?.SerializeToJson(JsonSerialization.OptionsForLogger);

                valueForInput = !string.IsNullOrEmpty(valueForInput)
                    ? $". {titleForInput}: {valueForInput}"
                    : string.Empty;

                ExtLogger.LogDebug($"{Title}{titleForStart}{valueForInput}");
            }
        }

        private void LogSuccessIfTestOrDebugEnabled()
        {
            if (ExtLogger != null)
            {
                string titleForSuccess = AppQueryResource.GetTitleForSuccess();
                string titleForResult = AppQueryResource.GetTitleForResult();
                string valueForResult = GetQueryResult().SerializeToJson(JsonSerialization.OptionsForLogger);

                ExtLogger.LogDebug($"{Title}{titleForSuccess}. {titleForResult}: {valueForResult}");
            }
        }

        #endregion Private methods
    }
}
