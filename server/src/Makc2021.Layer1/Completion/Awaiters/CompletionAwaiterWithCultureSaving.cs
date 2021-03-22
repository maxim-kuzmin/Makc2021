// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Makc2021.Layer1.Completion.Awaiters
{
    /// <summary>
    /// Ожидание завершения с сохранением культуры.
    /// </summary>
    public struct CompletionAwaiterWithCultureSaving : ICriticalNotifyCompletion
    {
        #region Properties

        private bool ContinueOnCapturedContext { get; set; }

        private Task Task { get; set; }

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
        public CompletionAwaiterWithCultureSaving(Task task, bool continueOnCapturedContext)
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
        public CompletionAwaiterWithCultureSaving GetAwaiter()
        {
            return this;
        }

        /// <summary>
        /// Получить результат.
        /// </summary>
        /// <returns>Результат.</returns>
        public void GetResult()
        {
            Task.GetAwaiter().GetResult();
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