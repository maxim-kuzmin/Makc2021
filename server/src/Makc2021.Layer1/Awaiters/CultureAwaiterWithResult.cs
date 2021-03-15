// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Makc2021.Layer1.Extensions;

namespace Makc2021.Layer1.Awaiters
{
    /// <summary>
    /// Объект ожидания задачи с возвращением результата и сохранением текущей культуры.
    /// </summary>
    /// <typeparam name="T">Тип результата выполнения задачи.</typeparam>
    public struct CultureAwaiterWithResult<T> : ICriticalNotifyCompletion
    {
        #region Properties

        private bool ContinueOnCapturedContext { get; set; }

        private Task<T> Task { get; set; }

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
        public CultureAwaiterWithResult(Task<T> task, bool continueOnCapturedContext)
        {
            Task = task;
            ContinueOnCapturedContext = continueOnCapturedContext;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить объект ожидания.
        /// </summary>
        /// <returns>Объект ожидания.</returns>
        public CultureAwaiterWithResult<T> GetAwaiter()
        {
            return this;
        }

        /// <summary>
        /// Получить результат выполнения задачи.
        /// </summary>
        /// <returns>Результат выполнения задачи.</returns>
        public T GetResult()
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