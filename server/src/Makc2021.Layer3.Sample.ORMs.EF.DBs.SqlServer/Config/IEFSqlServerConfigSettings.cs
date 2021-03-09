//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer.Config
{
    /// <summary>
    /// ORM "Entity Framework". База данных "Microsoft SQL Server". Настройки. Интерфейс.
    /// </summary>
    public interface IEFSqlServerConfigSettings
    {
        #region Properties

        /// <summary>
        /// Строка подключения.
        /// </summary>
        string ConnectionString { get; }

        #endregion Properties
    }
}