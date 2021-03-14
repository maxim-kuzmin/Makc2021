// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer1.Extensions;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Query.Services.Async
{
    /// <summary>
    /// Сервис асинхронного запроса с вводом и выводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public abstract class AsyncQueryWithInputAndOutputService<TInput, TOutput> : QueryWithInputAndOutputService<TInput, TOutput>
    {
        #region Constructors

        /// <inheritdoc/>
        public AsyncQueryWithInputAndOutputService(IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        ///  Выполнить.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        public async Task<TOutput> Execute(TInput input)
        {
            var functionToTransformInput = QueryHandler.FunctionToTransformInput;

            if (functionToTransformInput != null)
            {
                input = functionToTransformInput.Invoke(input);
            }

            var result = await DoExecute(input).ConfigureAwaitWithCurrentCulture(false);

            var functionToTransformOutput = QueryHandler.FunctionToTransformOutput;

            if (functionToTransformOutput != null)
            {
                result = functionToTransformOutput.Invoke(result);
            }

            return result;
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Действительно выполнить.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с выводом.</returns>
        protected abstract Task<TOutput> DoExecute(TInput input);

        #endregion Protected methods
    }
}
