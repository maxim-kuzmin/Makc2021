// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Query.Executions;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Services
{
    /// <summary>
    /// Сервис запроса с вводом и выводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class QueryWithInputAndOutputService<TInput, TOutput> : QueryService<QueryWithInputAndOutputHandler<TInput, TOutput>>
    {
        #region Constructors

        /// <inheritdoc/>
        public QueryWithInputAndOutputService(IErrorsResource resourceOfErrors)
            : base(new QueryWithInputAndOutputHandler<TInput, TOutput>(resourceOfErrors))
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
        public void OnSuccess(ILogger logger, QueryResultWithOutput<TOutput> queryResult, TInput input)
        {
            QueryHandler.OnSuccess(logger, queryResult, input);
        }

        #endregion Public methods
    }
}
