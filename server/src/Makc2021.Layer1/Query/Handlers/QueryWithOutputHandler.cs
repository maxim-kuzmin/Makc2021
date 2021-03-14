// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Executions
{
    /// <summary>
    /// Обработчик запроса с выводом.
    /// </summary>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class QueryWithOutputHandler<TOutput> : QueryHandler
    {
        #region Properties

        /// <summary>
        /// Функция преобразования вывода.
        /// </summary>
        public Func<TOutput, TOutput> FunctionToTransformOutput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        public Func<TOutput, IEnumerable<string>> FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        public Func<TOutput, IEnumerable<string>> FunctionToGetWarningMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public QueryWithOutputHandler(IErrorsResource resourceOfErrors)
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
        public void OnSuccess(ILogger logger, QueryResultWithOutput<TOutput> queryResult)
        {
            Func<IEnumerable<string>> funcGetSuccessMessages = null;

            if (FunctionToGetSuccessMessages != null)
            {
                funcGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(queryResult.Output);
            }

            Func<IEnumerable<string>> funcGetWarningMessages = null;

            if (FunctionToGetWarningMessages != null)
            {
                funcGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(queryResult.Output);
            }

            DoOnSuccess(
                logger,
                queryResult,
                funcGetSuccessMessages,
                funcGetWarningMessages
                );
        }

        #endregion Public methods
    }
}
