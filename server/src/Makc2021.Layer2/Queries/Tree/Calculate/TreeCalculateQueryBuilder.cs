// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer2.Queries.Tree.Calculate
{
    /// <summary>
    /// Построитель запроса вычисления дерева.
    /// </summary>
    public abstract class TreeCalculateQueryBuilder : TreeQueryBuilder
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public TreeCalculateQueryBuilder()
        {
            Prefix = "TreeCalculate_";
        }

        #endregion Constructors
    }
}
