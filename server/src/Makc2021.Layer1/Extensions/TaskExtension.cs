// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Makc2021.Layer1.Awaiters;

namespace Makc2021.Layer1.Extensions
{
    /// <summary>
    /// Расширение задачи.
    /// </summary>
    public static class TaskExtension
    {
        #region Public methods

        /// <summary>
        /// Настроить ожидание с сохранением текущей культуры.
        /// </summary>
        /// <param name="task">Задача.</param>
        /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
        /// <returns>Объект ожидания завершения задачи.</returns>
        public static CultureAwaiter ConfigureAwaitWithCurrentCulture(this Task task, bool continueOnCapturedContext)
        {
            return new CultureAwaiter(task, continueOnCapturedContext);
        }

        /// <summary>
        /// Настроить ожидание с сохранением текущей культуры.
        /// </summary>
        /// <typeparam name="T">Тип результата выполнения задачи.</typeparam>
        /// <param name="task">Задача.</param>
        /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
        /// <returns>Объект ожидания завершения задачи.</returns>
        public static CultureAwaiterWithResult<T> ConfigureAwaitWithCurrentCulture<T>(this Task<T> task, bool continueOnCapturedContext)
        {
            return new CultureAwaiterWithResult<T>(task, continueOnCapturedContext);
        }

        #endregion Public methods

        #region Internal methods

        /// <summary>
        /// Запланировать выполнение продолжения задачи.
        /// </summary>
        /// <param name="task">Задача.</param>
        /// <param name="continuation">Продолжение.</param>
        /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
        internal static void UnsafeOnCompleted(this Task task, Action continuation, bool continueOnCapturedContext)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var currentUICulture = CultureInfo.CurrentUICulture;

            task.ConfigureAwait(continueOnCapturedContext).GetAwaiter().UnsafeOnCompleted(() =>
            {
                var originalCulture = CultureInfo.CurrentCulture;
                var originalUICulture = CultureInfo.CurrentUICulture;

                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUICulture;

                try
                {
                    continuation();
                }
                finally
                {
                    CultureInfo.CurrentCulture = originalCulture;
                    CultureInfo.CurrentUICulture = originalUICulture;
                }
            });
        }

        #endregion Internal methods
    }
}