// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Обработчик запроса с входными и выходными данными.
    /// </summary>
    /// <typeparam name="TQueryInput">Тип входных данных запроса.</typeparam>
    /// <typeparam name="TQueryOutput">Тип выходных данных запроса.</typeparam>    
    public class QueryWithInputAndOutputHandler<TQueryInput, TQueryOutput> : QueryHandler, IQueryWithInputAndOutputHandler<TQueryInput, TQueryOutput>
    {
        #region Properties

        /// <summary>
        /// Функция преобразования ввода запроса.
        /// </summary>
        protected Func<TQueryInput, TQueryInput> FunctionToTransformQueryInput { get; set; }

        /// <summary>
        /// Функция преобразования вывода запроса.
        /// </summary>
        protected Func<TQueryOutput, TQueryOutput> FunctionToTransformQueryOutput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        protected Func<TQueryInput, TQueryOutput, IEnumerable<string>> FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        protected Func<TQueryInput, TQueryOutput, IEnumerable<string>> FunctionToGetWarningMessages { get; set; }

        /// <inheritdoc/>
        public TQueryInput QueryInput { get; private set; }

        /// <inheritdoc/>
        public QueryResultWithOutput<TQueryOutput> QueryResult { get; } = new QueryResultWithOutput<TQueryOutput>();

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public QueryWithInputAndOutputHandler(string queryName, IQueryResource appQueryResource, ILogger extLogger)
            : base(queryName, appQueryResource, extLogger)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void OnStart(TQueryInput queryInput)
        {
            QueryInput = FunctionToTransformQueryInput != null
                ? FunctionToTransformQueryInput.Invoke(queryInput)
                : queryInput;

            DoOnStart();
        }

        /// <inheritdoc/>
        public void OnSuccess(TQueryOutput queryOutput)
        {
            if (FunctionToTransformQueryOutput != null)
            {
                queryOutput = FunctionToTransformQueryOutput.Invoke(queryOutput);
            }

            QueryResult.Output = queryOutput;

            Func<IEnumerable<string>> functionToGetSuccessMessages = null;

            if (FunctionToGetSuccessMessages != null)
            {
                functionToGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(QueryInput, queryOutput);
            }

            Func<IEnumerable<string>> functionToGetWarningMessages = null;

            if (FunctionToGetWarningMessages != null)
            {
                functionToGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(QueryInput, queryOutput);
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
