// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Query.Executions;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Services
{
    /// <summary>
    /// Сервис запроса без ввода и вывода.
    /// </summary>
    public class QueryWithoutInputAndOutputService : QueryService<QueryWithoutInputAndOutputHandler>
    {
        #region Constructors

        /// <inheritdoc/>
        public QueryWithoutInputAndOutputService(IErrorsResource resourceOfErrors)
            : base(new QueryWithoutInputAndOutputHandler(resourceOfErrors))
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Обработать событие успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="queryResult">Результат запроса.</param>
        public void OnSuccess(ILogger logger, QueryResult queryResult)
        {
            QueryHandler.OnSuccess(logger, queryResult);
        }

        #endregion Public methods
    }
}
