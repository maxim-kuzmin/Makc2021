//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Common.Queries.Tree;
using Makc2021.Layer2.Trigger;

namespace Makc2021.Layer2.Queries.Tree.Trigger
{
    /// <summary>
    /// Запрос триггера дерева. Построитель.
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
