﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Обработчик запроса с входными данными.
    /// </summary>
    /// <typeparam name="TQueryInput">Тип входных данных запроса.</typeparam>
    public class QueryWithInputHandler<TQueryInput> : QueryHandler, IQueryWithInputHandler<TQueryInput>
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

        /// <inheritdoc/>
        public TQueryInput QueryInput { get; private set; }

        /// <inheritdoc/>
        public QueryResult QueryResult { get; private set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public QueryWithInputHandler(string queryName, IQueryResource queryResource, ILogger logger)
            : base(queryName, queryResource, logger)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void OnStart(TQueryInput queryInput, string queryCode = null)
        {
            QueryInput = FunctionToTransformQueryInput != null
                ? FunctionToTransformQueryInput.Invoke(queryInput)
                : queryInput;

            DoOnStart(queryCode);
        }

        /// <inheritdoc/>
        public void OnSuccess()
        {
            InitQueryResult(true);

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

        /// <inheritdoc/>
        public void OnSuccessWithResult(QueryResult queryResult)
        {
            QueryResult = queryResult;

            DoOnSuccess(null, null);
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

        /// <inheritdoc/>
        protected sealed override void InitQueryResult(bool isOk)
        {
            QueryResult = new QueryResult
            {
                IsOk = isOk,
                QueryCode = QueryCode
            };
        }

        #endregion Protected methods
    }
}
