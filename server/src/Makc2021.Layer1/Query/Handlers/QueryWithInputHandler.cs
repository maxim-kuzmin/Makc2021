// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Обработчик запроса с входными данными.
    /// </summary>
    /// <typeparam name="TQueryInput">Тип входных данных запроса.</typeparam>
    public class QueryWithInputHandler<TQueryInput> : QueryHandler
    {
        #region Properties

        /// <summary>
        /// Функция преобразования ввода запроса.
        /// </summary>
        protected Func<TQueryInput, TQueryInput> FunctionToTransformQueryInput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        protected Func<TQueryInput, IEnumerable<string>> FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        protected Func<TQueryInput, IEnumerable<string>> FunctionToGetWarningMessages { get; set; }

        /// <summary>
        /// Входные данные запроса.
        /// </summary>
        public TQueryInput QueryInput { get; private set; }

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        public QueryResult QueryResult { get; } = new QueryResult();

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public QueryWithInputHandler(string queryName, IErrorsResource appErrorsResource, ILogger extLogger)
            : base(queryName, appErrorsResource, extLogger)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Обработать начало запроса.
        /// </summary>
        /// <param name="queryInput">Входные данные запроса.</param>        
        public void OnStart(TQueryInput queryInput)
        {
            QueryInput = FunctionToTransformQueryInput != null
                ? FunctionToTransformQueryInput.Invoke(queryInput)
                : queryInput;

            DoOnStart();
        }

        /// <summary>
        /// Обработать успешное выполнение запроса.
        /// </summary>
        public void OnSuccess()
        {
            Func<IEnumerable<string>> functionToGetSuccessMessages = null;

            if (FunctionToGetSuccessMessages != null)
            {
                functionToGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(QueryInput);
            }

            Func<IEnumerable<string>> functionToGetWarningMessages = null;

            if (FunctionToGetWarningMessages != null)
            {
                functionToGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(QueryInput);
            }

            DoOnSuccess(functionToGetSuccessMessages, functionToGetWarningMessages);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override object GetQueryInput()
        {
            return QueryInput;
        }

        /// <inheritdoc/>
        protected sealed override QueryResult GetQueryResult()
        {
            return QueryResult;
        }

        #endregion Protected methods
    }
}
