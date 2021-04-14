// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer1.Query.Handlers
{
    /// <summary>
    /// Интерфейс обработчика запроса без входных и выходных данных.
    /// </summary>
    public interface IQueryWithoutInputAndOutputHandler : IQueryHandler
    {
        #region Properties

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        QueryResult QueryResult { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Обработать начало запроса.
        /// </summary>
        /// <param name="queryCode">Код запроса.</param>
        void OnStart(string queryCode = null);

        /// <summary>
        /// Обработать успешное выполнение запроса.
        /// </summary>
        public void OnSuccess();

        #endregion Methods
    }
}
