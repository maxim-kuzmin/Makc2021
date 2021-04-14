// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Обработчик запроса с входными и выходными данными.
    /// </summary>
    /// <typeparam name="TQueryInput">Тип входных данных запроса.</typeparam>
    /// <typeparam name="TQueryOutput">Тип выходных данных запроса.</typeparam>    
    public interface IQueryWithInputAndOutputHandler<TQueryInput, TQueryOutput> : IQueryHandler
    {
        #region Properties

        /// <summary>
        /// Входные данные запроса.
        /// </summary>
        TQueryInput QueryInput { get; }

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        QueryResultWithOutput<TQueryOutput> QueryResult { get; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Обработать начало запроса.
        /// </summary>
        /// <param name="queryInput">Входные данные запроса.</param>     
        /// <param name="queryCode">Код запроса.</param>
        void OnStart(TQueryInput queryInput, string queryCode = null);

        /// <summary>
        /// Обработать успешное выполнение запроса.
        /// </summary>
        /// <param name="queryOutput">Выходные данные запроса.</param>
        void OnSuccess(TQueryOutput queryOutput);

        /// <summary>
        /// Обработать успешное выполнение запроса.
        /// </summary>
        /// <param name="queryResult">Результат запроса.</param>
        void OnSuccess(QueryResultWithOutput<TQueryOutput> queryResult);

        #endregion Public methods
    }
}
