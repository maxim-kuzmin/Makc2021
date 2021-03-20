// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Обработчик запроса с выходными данными.
    /// </summary>
    /// <typeparam name="TQueryOutput">Тип выходных данных запроса.</typeparam>    
    public class QueryWithOutputHandler<TQueryOutput> : QueryHandler
    {
        #region Properties

        /// <summary>
        /// Функция преобразования вывода запроса.
        /// </summary>
        protected Func<TQueryOutput, TQueryOutput> FunctionToTransformQueryOutput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        protected Func<TQueryOutput, IEnumerable<string>> FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        protected Func<TQueryOutput, IEnumerable<string>> FunctionToGetWarningMessages { get; set; }

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        public QueryResultWithOutput<TQueryOutput> QueryResult { get; } = new QueryResultWithOutput<TQueryOutput>();

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public QueryWithOutputHandler(string queryName, IErrorsResource appErrorsResource, ILogger extLogger)
            : base(queryName, appErrorsResource, extLogger)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Обработать начало запроса.
        /// </summary>
        public void OnStart()
        {
            DoOnStart();
        }

        /// <summary>
        /// Обработать успешное выполнение запроса.
        /// </summary>
        /// <param name="queryOutput">Выходные данные запроса.</param>
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
                functionToGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(queryOutput);
            }

            Func<IEnumerable<string>> functionToGetWarningMessages = null;

            if (FunctionToGetWarningMessages != null)
            {
                functionToGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(queryOutput);
            }

            DoOnSuccess(functionToGetSuccessMessages, functionToGetWarningMessages);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override object GetQueryInput()
        {
            return null;
        }

        /// <inheritdoc/>
        protected sealed override QueryResult GetQueryResult()
        {
            return QueryResult;
        }

        #endregion Protected methods
    }
}
