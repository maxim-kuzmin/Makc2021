﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer2.Sql.Queries.Tree.Nodes
{
    /// <summary>
    /// Ось запроса узлов дерева.
    /// </summary>
    public enum TreeNodesQueryAxis
    {
        /// <summary>
        /// Отсутствует.
        /// </summary>
        None = 0,
        /// <summary>
        /// Все.
        /// </summary>
        All = 1,
        /// <summary>
        /// Предок.
        /// </summary>
        Ancestor = 2,
        /// <summary>
        /// Предок или корневой узел.
        /// </summary>
        AncestorOrSelf = 3,
        /// <summary>
        /// Ребёнок.
        /// </summary>
        Child = 4,
        /// <summary>
        /// Ребёнок или корневой узел.
        /// </summary>
        ChildOrSelf = 5,
        /// <summary>
        /// Потомок.
        /// </summary>
        Descendant = 6,
        /// <summary>
        /// Потомок или корневой узел.
        /// </summary>
        DescendantOrSelf = 7,
        /// <summary>
        /// Родитель или корневой узел.
        /// </summary>
        ParentOrSelf = 8
    }
}
