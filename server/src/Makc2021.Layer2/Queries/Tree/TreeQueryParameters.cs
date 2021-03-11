//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data.Common;

namespace Makc2021.Layer2.Queries.Tree
{
    /// <summary>
    /// Параметры запроса дерева.
    /// </summary>
    public class TreeQueryParameters
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public List<DbParameter> Ids { get; private set; } = new();

        #endregion Properties
    }
}
