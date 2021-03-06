//Author Maxim Kuzmin//makc//

using System.Collections.Generic;

namespace Makc2021.Layer1.Data.Base.Queries.Identity.Reseed
{
    /// <summary>
    /// Данные. Основа. Запросы. Идентичность. Перезаполнение. Построитель.
    /// </summary>
    public abstract class DataBaseQueryIdentityReseedBuilder
    {
        #region Properties

        /// <summary>
        /// Таблицы.
        /// </summary>
        public List<DataBaseQueryIdentityReseedInput> Inputs { get; private set; }
            = new List<DataBaseQueryIdentityReseedInput>();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить результирующий SQL.
        /// </summary>
        public abstract string GetResultSql();

        #endregion Public methods
    }
}
