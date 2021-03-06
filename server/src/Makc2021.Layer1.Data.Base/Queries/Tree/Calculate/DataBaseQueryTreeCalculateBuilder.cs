//Author Maxim Kuzmin//makc//

using  Makc2021.Layer1.Base.Data.Queries.Tree;

namespace Makc2021.Layer1.Data.Base.Queries.Tree.Calculate
{
    /// <summary>
    /// Данные. Основа. Запросы. Дерево. Вычисление. Построитель.
    /// </summary>
    public abstract class DataBaseQueryTreeCalculateBuilder : BaseDataQueryTreeBuilder
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DataBaseQueryTreeCalculateBuilder()
        {
            Prefix = "TreeCalculate_";
        }

        #endregion Constructors
    }
}
