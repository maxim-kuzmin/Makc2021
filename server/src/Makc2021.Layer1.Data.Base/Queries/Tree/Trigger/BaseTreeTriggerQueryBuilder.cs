//Author Maxim Kuzmin//makc//

using Makc2021.Layer1.Base.Data.Queries.Tree;
using Makc2021.Layer1.Base.Data.Trigger;

namespace Makc2021.Layer1.Data.Base.Queries.Tree.Trigger
{
    /// <summary>
    /// Основа. Запрос триггера дерева. Построитель.
    /// </summary>
    public abstract class BaseTreeTriggerQueryBuilder : BaseTreeQueryBuilder
    {
        #region Properties

        /// <summary>
        /// Действие.
        /// </summary>
        public BaseTriggerAction Action { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public BaseTreeTriggerQueryBuilder()
        {
            Prefix = "TreeTrigger_";
        }

        #endregion Constructors
    }
}
