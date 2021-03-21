// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Интерфейс обработчика запроса с выходными данными.
    /// </summary>
    /// <typeparam name="TQueryOutput">Тип выходных данных запроса.</typeparam>    
    public interface IQueryWithOutputHandler<TQueryOutput> : IQueryHandler
    {
        #region Properties

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        QueryResultWithOutput<TQueryOutput> QueryResult { get; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Обработать начало запроса.
        /// </summary>
        void OnStart();

        /// <summary>
        /// Обработать успешное выполнение запроса.
        /// </summary>
        /// <param name="queryOutput">Выходные данные запроса.</param>
        void OnSuccess(TQueryOutput queryOutput);

        #endregion Public methods
    }
}
