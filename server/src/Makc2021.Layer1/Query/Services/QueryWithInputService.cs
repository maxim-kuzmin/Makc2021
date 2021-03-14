// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Query.Executions;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Services
{
    /// <summary>
    /// Сервис запроса с вводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    public class QueryWithInputService<TInput> : QueryService<QueryWithInputHandler<TInput>>
    {
        #region Constructors

        /// <inheritdoc/>
        public QueryWithInputService(IErrorsResource resourceOfErrors)
            : base(new QueryWithInputHandler<TInput>(resourceOfErrors))
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Обработать событие успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="queryResult">Результат запроса.</param>
        /// <param name="input">Ввод.</param>
        public void OnSuccess(ILogger logger, QueryResult queryResult, TInput input)
        {
            QueryHandler.OnSuccess(logger, queryResult, input);
        }

        #endregion Public methods
    }
}