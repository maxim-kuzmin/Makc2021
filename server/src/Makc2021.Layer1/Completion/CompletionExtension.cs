// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Makc2021.Layer1.Completion.Awaiters;

namespace Makc2021.Layer1.Completion
{
    /// <summary>
    /// Расширение завершения.
    /// </summary>
    public static class CompletionExtension
    {
        #region Public methods

        /// <summary>
        /// Настроить ожидание с сохранением культуры.
        /// </summary>
        /// <param name="task">Задача.</param>
        /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
        /// <returns>Ожидание завершения с сохранением культуры.</returns>
        public static CompletionAwaiterWithCultureSaving ConfigureAwaitWithCultureSaving(
            this Task task,
            bool continueOnCapturedContext
            )
        {
            return new CompletionAwaiterWithCultureSaving(task, continueOnCapturedContext);
        }

        /// <summary>
        /// Настроить ожидание с сохранением культуры.
        /// </summary>
        /// <typeparam name="TResult">Тип результата.</typeparam>
        /// <param name="task">Задача.</param>
        /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
        /// <returns>Ожидание завершения с сохранением культуры и результатом.</returns>
        public static CompletionAwaiterWithCultureSavingAndResult<TResult> ConfigureAwaitWithCultureSaving<TResult>(
            this Task<TResult> task,
            bool continueOnCapturedContext
            )
        {
            return new CompletionAwaiterWithCultureSavingAndResult<TResult>(task, continueOnCapturedContext);
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