//Author Maxim Kuzmin//makc//

using  Makc2021.Layer1.Base.Data.Queries.Tree;

namespace Makc2021.Layer1.Data.Base.Queries.Tree.Calculate
{
    /// <summary>
    /// Основа. Запрос вычисления дерева. Построитель.
    /// </summary>
    public abstract class BaseTreeCalculateQueryBuilder : BaseTreeQueryBuilder
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public BaseTreeCalculateQueryBuilder()
        {
            Prefix = "TreeCalculate_";
        }

        #endregion Constructors
    }
}
