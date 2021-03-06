// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Query.Services.Sync
{
    /// <summary>
    /// Сервис синхронного запроса с вводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    public class SyncQueryWithInputService<TInput> : QueryWithInputService<TInput>
    {
        #region Properties

        /// <summary>
        /// Действие, предназначенное для выполнения.
        /// </summary>
        public Action<TInput> ActionToExecute { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public SyncQueryWithInputService(IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
        }

        #endregion Constructors
        
        #region Public methods

        /// <summary>
        /// Выполнить.
        /// </summary>
        /// <param name="input">Ввод.</param>
        public void Execute(TInput input)
        {
            var functionToTransformInput = QueryHandler.FunctionToTransformInput;

            if (functionToTransformInput != null)
            {
                input = functionToTransformInput.Invoke(input);
            }

            ActionToExecute.Invoke(input);
        }

        #endregion Public methods
    }
}