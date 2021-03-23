// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Makc2021.Layer1.Completion.Awaiters
{
    /// <summary>
    /// Ожидание завершения с сохранением культуры и результатом.
    /// </summary>
    /// <typeparam name="TResult">Тип результата.</typeparam>
    public struct CompletionAwaiterWithCultureSavingAndResult<TResult> : ICriticalNotifyCompletion
    {
        #region Properties

        private bool ContinueOnCapturedContext { get; set; }

        private Task<TResult> Task { get; set; }

        /// <summary>
        /// Признак завершения задачи.
        /// </summary>
        public bool IsCompleted => Task.IsCompleted;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="task">Задача.</param>
        /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
        public CompletionAwaiterWithCultureSavingAndResult(Task<TResult> task, bool continueOnCapturedContext)
        {
            Task = task;
            ContinueOnCapturedContext = continueOnCapturedContext;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить ожидание.
        /// </summary>
        /// <returns>Ожидание.</returns>
        public CompletionAwaiterWithCultureSavingAndResult<TResult> GetAwaiter()
        {
            return this;
        }

        /// <summary>
        /// Получить результат.
        /// </summary>
        /// <returns>Результат.</returns>
        public TResult GetResult()
        {
            return Task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Обработчик завершения задачи.
        /// </summary>
        /// <param name="continuation">Продолжение.</param>
        public void OnCompleted(Action continuation)
        {
            // Компилятор никогда не вызовет этот метод.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Запланировать выполнение продолжения задачи.
        /// </summary>
        /// <param name="continuation">Продолжение.</param>
        public void UnsafeOnCompleted(Action continuation)
        {
            Task.UnsafeOnCompleted(continuation, ContinueOnCapturedContext);
        }

        #endregion Public methods
    }
}