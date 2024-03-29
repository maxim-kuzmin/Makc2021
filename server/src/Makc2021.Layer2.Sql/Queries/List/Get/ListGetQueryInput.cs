﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Query;

namespace Makc2021.Layer2.Sql.Queries.List.Get
{
    /// <summary>
    /// Входные данные запроса на получение списка.
    /// </summary>
    public abstract class ListGetQueryInput : QueryInput
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

        /// <inheritdoc/>
        public override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (!string.IsNullOrWhiteSpace(SortDirection)
                &&
                (
                    !QueryOptions.SORT_DIRECTION_ASC.Equals(SortDirection, StringComparison.OrdinalIgnoreCase)
                    &&
                    !QueryOptions.SORT_DIRECTION_DESC.Equals(SortDirection, StringComparison.OrdinalIgnoreCase)
                ))
            {
                result.Add(nameof(SortField));
            }

            return result;
        }

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
                PageSize = 0;
            }
        }

        #endregion Public methods
    }
}
