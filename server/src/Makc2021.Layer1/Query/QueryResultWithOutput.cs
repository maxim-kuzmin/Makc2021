// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer1.Query
{
    /// <summary>
    /// Результат запроса с выводом.
    /// </summary>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>
    public class QueryResultWithOutput<TOutput> : QueryResult
    {
        #region Properties

        /// <summary>
        /// Вывод.
        /// </summary>
        public TOutput Output { get; set; }

        #endregion Properties
    }
}
