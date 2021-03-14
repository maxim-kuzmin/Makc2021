// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Query.Services.Async
{
    /// <summary>
    /// Сервис асинхронного запроса без ввода и вывода.
    /// </summary>
    public class AsyncQueryWithoutInputAndOutputService : QueryWithoutInputAndOutputService
    {
        #region Properties

        /// <summary>
        /// Функция, предназначенная для выполнения.
        /// </summary>
        public Func<Task> FunctionToExecute { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public AsyncQueryWithoutInputAndOutputService(IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        ///  Выполнить.
        /// </summary>
        /// <returns>Задача.</returns>
        public Task Execute()
        {
            return FunctionToExecute.Invoke();
        }

        #endregion Public methods
    }
}
