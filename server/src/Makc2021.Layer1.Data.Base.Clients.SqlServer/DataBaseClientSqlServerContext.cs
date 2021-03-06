//Author Maxim Kuzmin//makc//

using Makc2021.Layer1.Base.Data;

namespace Makc2021.Layer1.Data.Base.Clients.SqlServer
{
    /// <summary>
    /// Данные. Основа. Клиенты. SQL Server. Контекст.
    /// </summary>
    public class DataBaseClientSqlServerContext
    {
        #region Properties

        /// <summary>
        /// Поставщик.
        /// </summary>
        public IDataBaseProvider Provider { get; private set; } = new DataBaseClientSqlServerProvider();

        #endregion Properties
    }
}
