﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Serialization.Json;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Обработчик запроса.
    /// </summary>
    public abstract class QueryHandler : IQueryHandler
    {
        #region Properties

        private string QueryName { get; set; }

        private string Title { get; set; }

        /// <summary>
        /// Ресурс запроса.
        /// </summary>
        protected IQueryResource QueryResource { get; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// Функция получения сообщений об ошибках.
        /// </summary>
        protected Func<Exception, IEnumerable<string>> FunctionToGetErrorMessages { get; set; }

        /// <summary>
        /// Код запроса.
        /// </summary>
        protected string QueryCode { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="queryName">Имя запроса.</param>
        /// <param name="queryResource">Ресурс запроса.</param>
        /// <param name="logger">Регистратор.</param>
        public QueryHandler(string queryName, IQueryResource queryResource, ILogger logger)
        {
            QueryName = queryName;
            QueryResource = queryResource;
            Logger = logger;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void OnError(Exception exception = null)
        {
            if (exception != null)
            {
                InitQueryResult(false);
            }

            var queryResult = GetQueryResult();

            string errorMessage;

            var errorMessages = GetErrorMessages(exception);

            if (errorMessages != null && errorMessages.Any())
            {
                queryResult.ErrorMessages.UnionWith(errorMessages);

                errorMessage = string.Join(". ", errorMessages).Replace("!.", "!").Replace("?.", "?");
            }
            else
            {
                errorMessage = QueryResource.GetErrorMessageForDefault();

                queryResult.ErrorMessages.Add(errorMessage);
            }

            if (Logger != null)
            {
                string titleForError = QueryResource.GetTitleForError();

                Logger.LogError(exception, $"{Title}{titleForError}. {errorMessage}");
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Сделать в начале запроса.
        /// </summary>
        /// <param name="queryCode">Код запроса.</param>
        protected virtual void DoOnStart(string queryCode)
        {
            QueryCode = string.IsNullOrWhiteSpace(queryCode) ? QueryHelper.CreateQueryCode() : queryCode;

            string titleForQueryCode = QueryResource.GetTitleForQueryCode();

            if (!string.IsNullOrWhiteSpace(queryCode))
            {
                QueryCode = queryCode;
            }

            Title = $"{QueryName}. {titleForQueryCode}: {QueryCode}. ";

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

            if (queryResult.IsOk)
            {
                if (functionToGetSuccessMessages != null)
                {
                    var messages = functionToGetSuccessMessages();

                    if (messages != null && messages.Any())
                    {
                        queryResult.SuccessMessages.UnionWith(messages);
                    }
                }

                if (functionToGetWarningMessages != null)
                {
                    var messages = functionToGetWarningMessages();

                    if (messages != null && messages.Any())
                    {
                        queryResult.WarningMessages.UnionWith(messages);
                    }
                }

#if TEST || DEBUG
                LogSuccessIfTestOrDebugEnabled();
#endif
            }
            else
            {
                OnError();
            }
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

        /// <summary>
        /// Инициализировать результат запроса.
        /// </summary>
        /// <param name="isOk">Признак успешности выполнения.</param>
        protected abstract void InitQueryResult(bool isOk);

        #endregion Protected methods

        #region Private methods

        private IEnumerable<string> GetErrorMessages(Exception exception)
        {
            IEnumerable<string> result = null;

            if (FunctionToGetErrorMessages != null)
            {
                result = FunctionToGetErrorMessages.Invoke(exception);
            }

            if (result == null || !result.Any())
            {
                string errorMessage = null;

                if (exception is CommonException)
                {
                    errorMessage = exception.Message;
                }

                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    result = new[] { errorMessage };
                }
            }

            return result;
        }

        private void LogStartIfTestOrDebugEnabled()
        {
            if (Logger != null)
            {
                object queryInput = GetQueryInput();

                string titleForStart = QueryResource.GetTitleForStart();
                string titleForInput = QueryResource.GetTitleForInput();
                string valueForInput = queryInput?.SerializeToJson(JsonSerializationOptions.ForLogger);

                valueForInput = !string.IsNullOrEmpty(valueForInput)
                    ? $". {titleForInput}: {valueForInput}"
                    : string.Empty;

                Logger.LogDebug($"{Title}{titleForStart}{valueForInput}");
            }
        }

        private void LogSuccessIfTestOrDebugEnabled()
        {
            if (Logger != null)
            {
                var queryResult = GetQueryResult();

                string titleForSuccess = QueryResource.GetTitleForSuccess();
                string titleForResult = QueryResource.GetTitleForResult();
                string valueForResult = queryResult.SerializeToJson(JsonSerializationOptions.ForLogger);

                Logger.LogDebug($"{Title}{titleForSuccess}. {titleForResult}: {valueForResult}");
            }
        }

        #endregion Private methods
    }
}
