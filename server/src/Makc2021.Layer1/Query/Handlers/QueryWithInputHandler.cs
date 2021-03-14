// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer1.Query.Executions
{
    /// <summary>
    /// Обработчик запроса с вводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    public class QueryWithInputHandler<TInput> : QueryHandler
    {
        #region Properties

        /// <summary>
        /// Функция преобразования ввода.
        /// </summary>
        public Func<TInput, TInput> FunctionToTransformInput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        public Func<TInput, IEnumerable<string>> FunctionToGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        public Func<TInput, IEnumerable<string>> FunctionToGetWarningMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public QueryWithInputHandler(IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// В случае успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="result">Результат выполнения.</param>
        /// <param name="input">Ввод.</param>
        public void OnSuccess(ILogger logger, QueryResult result, TInput input)
        {
            Func<IEnumerable<string>> funcGetSuccessMessages = null;

            if (FunctionToGetSuccessMessages != null)
            {
                funcGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(input);
            }

            Func<IEnumerable<string>> funcGetWarningMessages = null;

            if (FunctionToGetWarningMessages != null)
            {
                funcGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(input);
            }

            DoOnSuccess(
                logger,
                result,
                funcGetSuccessMessages,
                funcGetWarningMessages
                );
        }

        #endregion Public methods
    }
}
