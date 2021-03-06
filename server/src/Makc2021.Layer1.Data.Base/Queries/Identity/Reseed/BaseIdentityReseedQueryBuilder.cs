//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer1.Data.Base.Queries.Identity.Reseed
{
    /// <summary>
    /// Основа. Запрос перезаполнения идентичности. Построитель.
    /// </summary>
    public abstract class BaseIdentityReseedQueryBuilder
    {
        #region Properties

        /// <summary>
        /// Таблицы.
        /// </summary>
        public List<BaseIdentityReseedQueryInput> Inputs { get; private set; }
            = new List<BaseIdentityReseedQueryInput>();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить результирующий SQL.
        /// </summary>
        public abstract string GetResultSql();

        #endregion Public methods
    }
}
