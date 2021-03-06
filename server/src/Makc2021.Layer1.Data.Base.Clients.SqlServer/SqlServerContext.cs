//Author Maxim Kuzmin//makc//

using Makc2021.Layer1.Base.Data;

namespace Makc2021.Layer1.Data.Base.Clients.SqlServer
{
    /// <summary>
    /// Клиент базы данных "Microsoft SQL Server". Контекст.
    /// </summary>
    public class SqlServerContext
    {
        #region Properties

        /// <summary>
        /// Поставщик.
        /// </summary>
        public IBaseProvider Provider { get; private set; } = new SqlServerProvider();

        #endregion Properties
    }
}
