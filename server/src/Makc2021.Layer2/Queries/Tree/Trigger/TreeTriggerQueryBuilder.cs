// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer2.Trigger;

namespace Makc2021.Layer2.Queries.Tree.Trigger
{
    /// <summary>
    /// Построитель запроса триггера дерева.
    /// </summary>
    public abstract class TreeTriggerQueryBuilder : TreeQueryBuilder
    {
        #region Properties

        /// <summary>
        /// Действие.
        /// </summary>
        public TriggerAction Action { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public TreeTriggerQueryBuilder()
        {
            Prefix = "TreeTrigger_";
        }

        #endregion Constructors
    }
}
