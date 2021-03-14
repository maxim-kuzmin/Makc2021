// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;

namespace Makc2021.Layer1.Extensions
{
    /// <summary>
    /// Расширение коллекции.
    /// </summary>
    public static class CollectionExtension
    {
        #region Public methods

        /// <summary>
        /// Добавить диапазон.
        /// </summary>
        /// <typeparam name="T">Тип элементов.</typeparam>
        /// <param name="collection">Коллекция.</param>
        /// <param name="items">Элементы.</param>
        public static void AddRange<T>(this HashSet<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        #endregion Public methods
    }
}
