//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data.Common;

namespace  Makc2021.Layer2.Common.Queries.Tree
{
    /// <summary>
    /// Запрос дерева. Параметры.
    /// </summary>
    public class TreeQueryParameters
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public List<DbParameter> Ids { get; private set; } = new List<DbParameter>();

        #endregion Properties
    }
}
