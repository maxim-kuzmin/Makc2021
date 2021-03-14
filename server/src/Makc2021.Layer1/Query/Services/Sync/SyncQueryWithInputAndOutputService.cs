// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Query.Services.Sync
{
    /// <summary>
    /// Сервис синхронного запроса с вводом и выводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class SyncQueryWithInputAndOutputService<TInput, TOutput> : QueryWithInputAndOutputService<TInput, TOutput>
    {
        #region Properties

        /// <summary>
        /// Функция, предназначенная для выполнения.
        /// </summary>
        public Func<TInput, TOutput> FunctionToExecute { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public SyncQueryWithInputAndOutputService(IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Выполнить.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Вывод.</returns>
        public TOutput Execute(TInput input)
        {
            var functionToTransformInput = QueryHandler.FunctionToTransformInput;

            if (functionToTransformInput != null)
            {
                input = functionToTransformInput.Invoke(input);
            }

            var result = FunctionToExecute.Invoke(input);

            var functionToTransformOutput = QueryHandler.FunctionToTransformOutput;

            if (functionToTransformOutput != null)
            {
                result = functionToTransformOutput.Invoke(result);
            }

            return result;
        }

        #endregion Public methods
    }
}
