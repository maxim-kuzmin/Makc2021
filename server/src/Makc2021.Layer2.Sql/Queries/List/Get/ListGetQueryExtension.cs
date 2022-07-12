// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Linq;

namespace Makc2021.Layer2.Sql.Queries.List.Get
{
    /// <summary>
    /// Расширение запроса на получение списка.
    /// </summary>
    public static class ListGetQueryExtension
    {
        #region Public methods

        /// <summary>
        /// Применить пагинацию.
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемых данных.</typeparam>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Входные данные.</param>
        /// <returns>Запрос страницы.</returns>
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, ListGetQueryInput input)
        {
            return query.Skip((input.PageNumber - 1) * input.PageSize).Take(input.PageSize);
        }

        #endregion Public methods
    }
}
