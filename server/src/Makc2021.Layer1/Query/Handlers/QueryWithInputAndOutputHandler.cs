// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Executions
{
    /// <summary>
    /// Обработчик запроса с вводом и выводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class QueryWithInputAndOutputHandler<TInput, TOutput> : QueryHandler
    {
        #region Properties

        /// <summary>
        /// Функция преобразования ввода.
        /// </summary>
        public Func<TInput, TInput> FunctionToTransformInput { get; set; }

        /// <summary>
        /// Функция преобразования вывода.
        /// </summary>
        public Func<TOutput, TOutput> FunctionToTransformOutput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        public Func<TInput, TOutput, IEnumerable<string>> FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        public Func<TInput, TOutput, IEnumerable<string>> FunctionToGetWarningMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public QueryWithInputAndOutputHandler(IErrorsResource resourceOfErrors)
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
        /// <param name="input">Ввод.</param>        
        public void OnSuccess(ILogger logger, QueryResultWithOutput<TOutput> queryResult, TInput input)
        {
            Func<IEnumerable<string>> funcGetSuccessMessages = null;

            if (FunctionToGetSuccessMessages != null)
            {
                funcGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(input, queryResult.Output);
            }

            Func<IEnumerable<string>> funcGetWarningMessages = null;

            if (FunctionToGetWarningMessages != null)
            {
                funcGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(input, queryResult.Output);
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
