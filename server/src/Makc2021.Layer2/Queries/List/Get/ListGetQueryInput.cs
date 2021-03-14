// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer2.Queries.List.Get
{
    /// <summary>
    /// Ввод запроса на получение списка.
    /// </summary>
    public abstract class ListGetQueryInput
    {
        #region Properties

        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Размер страницы.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Поле сортировки.
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// Направление сортировки.
        /// </summary>
        public string SortDirection { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public virtual void Normalize()
        {
            if (PageNumber < 1)
            {
                PageNumber = 1;
            }

            if (PageSize < 1)
            {
                PageSize = int.MaxValue;
            }
        }

        #endregion Public methods
    }
}
