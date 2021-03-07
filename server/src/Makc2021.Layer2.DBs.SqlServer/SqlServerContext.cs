//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.DBs.SqlServer
{
    /// <summary>
    /// База данных "Microsoft SQL Server". Контекст.
    /// </summary>
    public class SqlServerContext
    {
        #region Properties

        /// <summary>
        /// Поставщик.
        /// </summary>
        public IProvider Provider { get; private set; } = new SqlServerProvider();

        #endregion Properties
    }
}
