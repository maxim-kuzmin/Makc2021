//Author Maxim Kuzmin//makc//

using  Makc2021.Layer2.Common.Queries.Tree;

namespace Makc2021.Layer2.Queries.Tree.Calculate
{
    /// <summary>
    /// Запрос вычисления дерева. Построитель.
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
