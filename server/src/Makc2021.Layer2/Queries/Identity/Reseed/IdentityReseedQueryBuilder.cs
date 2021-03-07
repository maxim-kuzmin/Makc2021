//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer2.Queries.Identity.Reseed
{
    /// <summary>
    /// Запрос перезаполнения идентичности. Построитель.
    /// </summary>
    public abstract class IdentityReseedQueryBuilder
    {
        #region Properties

        /// <summary>
        /// Таблицы.
        /// </summary>
        public List<IdentityReseedQueryInput> Inputs { get; private set; }
            = new List<IdentityReseedQueryInput>();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить результирующий SQL.
        /// </summary>
        public abstract string GetResultSql();

        #endregion Public methods
    }
}
