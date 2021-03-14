// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Executions
{
    /// <summary>
    /// Обработчик запроса без ввода и вывода.
    /// </summary>
    public class QueryWithoutInputAndOutputHandler : QueryHandler
    {
        #region Properties

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        public Func<IEnumerable<string>> FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        public Func<IEnumerable<string>> FunctionToGetWarningMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public QueryWithoutInputAndOutputHandler(IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// В случае успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="queryResult">Результат запроса.</param>
        public void OnSuccess(ILogger logger, QueryResult queryResult)
        {
            DoOnSuccess(
                logger,
                queryResult,
                FunctionToGetSuccessMessages,
                FunctionToGetWarningMessages
                );
        }

        #endregion Public methods
    }
}
