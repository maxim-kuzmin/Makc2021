//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data.Common;

namespace  Makc2021.Layer1.Base.Data.Queries.Tree
{
    /// <summary>
    /// Основа. Запрос дерева. Параметры.
    /// </summary>
    public class BaseTreeQueryParameters
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public List<DbParameter> Ids { get; private set; } = new List<DbParameter>();

        #endregion Properties
    }
}
