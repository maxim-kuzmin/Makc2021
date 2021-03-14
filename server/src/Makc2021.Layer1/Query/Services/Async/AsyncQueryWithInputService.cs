// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Query.Services.Async
{
    /// <summary>
    /// Сервис асинхронного запроса с вводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    public class AsyncQueryWithInputService<TInput> : QueryWithInputService<TInput>
    {
        #region Properties

        /// <summary>
        /// Функция, предназначенная для выполнения.
        /// </summary>
        public Func<TInput, Task> FunctionToExecute { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public AsyncQueryWithInputService(IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        ///  Выполнить.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public Task Execute(TInput input)
        {
            var functionToTransformInput = QueryHandler.FunctionToTransformInput;

            if (functionToTransformInput != null)
            {
                input = functionToTransformInput.Invoke(input);
            }

            return FunctionToExecute.Invoke(input);
        }

        #endregion Public methods
    }
}
