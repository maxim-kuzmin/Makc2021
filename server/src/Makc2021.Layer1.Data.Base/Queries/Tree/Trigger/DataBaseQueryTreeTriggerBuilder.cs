//Author Maxim Kuzmin//makc//

using Makc2021.Layer1.Base.Data.Queries.Tree;
using Makc2021.Layer1.Base.Data.Trigger;

namespace Makc2021.Layer1.Data.Base.Queries.Tree.Trigger
{
    /// <summary>
    /// Данные. Основа. Запросы. Дерево. Триггер. Построитель.
    /// </summary>
    public abstract class DataBaseQueryTreeTriggerBuilder : BaseDataQueryTreeBuilder
    {
        #region Properties

        /// <summary>
        /// Действие.
        /// </summary>
        public BaseDataTriggerAction Action { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataBaseQueryTreeTriggerBuilder()
        {
            Prefix = "TreeTrigger_";
        }

        #endregion Constructors
    }
}
