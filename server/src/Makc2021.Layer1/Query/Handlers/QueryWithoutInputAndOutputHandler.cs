// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Обработчик запроса без входных и выходных данных.
    /// </summary>
    public class QueryWithoutInputAndOutputHandler : QueryHandler
    {
        #region Properties

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        protected Func<IEnumerable<string>> FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        protected Func<IEnumerable<string>> FunctionToGetWarningMessages { get; set; }

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        protected QueryResult QueryResult { get; } = new QueryResult();

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public QueryWithoutInputAndOutputHandler(string queryName, IQueryResource appQueryResource, ILogger extLogger)
            : base(queryName, appQueryResource, extLogger)
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
        public void OnSuccess()
        {
            DoOnSuccess(FunctionToGetSuccessMessages, FunctionToGetWarningMessages);
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
