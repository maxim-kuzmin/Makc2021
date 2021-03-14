// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Query.Services.Sync
{
    /// <summary>
    /// Сервис синхронного запроса без ввода и вывода.
    /// </summary>
    public class SyncQueryWithoutInputAndOutputService : QueryWithoutInputAndOutputService
    {
        #region Properties

        /// <summary>
        /// Действие, предназначенное для выполнения.
        /// </summary>
        public Action ActionToExecute { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceOfErrors">Ресурс ошибок.</param>
        public SyncQueryWithoutInputAndOutputService(IErrorsResource resourceOfErrors)
            : base(resourceOfErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Выполнить.
        /// </summary>
        public void Execute()
        {
            ActionToExecute.Invoke();
        }

        #endregion Public methods
    }
}
