// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Query.Services.Sync
{
    /// <summary>
    /// Сервис синхронного запроса с выводом.
    /// </summary>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class SyncQueryWithOutputService<TOutput> : QueryWithOutputService<TOutput>
    {
        #region Properties

        /// <summary>
        /// Функция, предназначенная для выполнения.
        /// </summary>
        public Func<TOutput> FunctionToExecute { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public SyncQueryWithOutputService(IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Выполнить.
        /// </summary>        
        /// <returns>Вывод.</returns>
        public TOutput Execute()
        {
            var result = FunctionToExecute.Invoke();

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
