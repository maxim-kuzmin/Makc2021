// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Интерфейс обработчика запроса с входными данными.
    /// </summary>
    /// <typeparam name="TQueryInput">Тип входных данных запроса.</typeparam>
    public interface IQueryWithInputHandler<TQueryInput> : IQueryHandler
    {
        #region Properties

        /// <summary>
        /// Входные данные запроса.
        /// </summary>
        TQueryInput QueryInput { get; }

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        QueryResult QueryResult { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Обработать начало запроса.
        /// </summary>
        /// <param name="queryInput">Входные данные запроса.</param>        
        void OnStart(TQueryInput queryInput);

        /// <summary>
        /// Обработать успешное выполнение запроса.
        /// </summary>
        void OnSuccess();

        #endregion Methods
    }
}
