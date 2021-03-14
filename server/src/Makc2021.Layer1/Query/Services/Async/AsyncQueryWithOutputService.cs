// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Makc2021.Layer1.Extensions;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Query.Services.Async
{
    /// <summary>
    /// Сервис асинхронного запроса с выводом.
    /// </summary>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class AsyncQueryWithOutputService<TOutput> : QueryWithOutputService<TOutput>
    {
        #region Properties

        /// <summary>
        /// Выполняемое.
        /// </summary>
        public Func<Task<TOutput>> FunctionToExecute { get; protected set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="functionToExecute">Функция, предназначенная для выполнения.</param>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public AsyncQueryWithOutputService(Func<Task<TOutput>> functionToExecute, IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
            FunctionToExecute = functionToExecute;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        ///  Выполнить.
        /// </summary>        
        /// <returns>Задача с выводом.</returns>
        public async Task<TOutput> Execute()
        {
            var result = await FunctionToExecute.Invoke().ConfigureAwaitWithCurrentCulture(false);

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
