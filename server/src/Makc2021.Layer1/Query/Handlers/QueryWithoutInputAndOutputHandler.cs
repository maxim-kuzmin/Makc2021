﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Обработчик запроса без входных и выходных данных.
    /// </summary>
    public class QueryWithoutInputAndOutputHandler : QueryHandler, IQueryWithoutInputAndOutputHandler
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

        /// <inheritdoc/>
        public QueryResult QueryResult { get; private set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public QueryWithoutInputAndOutputHandler(string queryName, IQueryResource queryResource, ILogger logger)
            : base(queryName, queryResource, logger)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void OnStart(string queryCode = null)
        {
            DoOnStart(queryCode);
        }

        /// <inheritdoc/>
        public void OnSuccess()
        {
            InitQueryResult(true);

            DoOnSuccess(FunctionToGetSuccessMessages, FunctionToGetWarningMessages);
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
            return null;
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
