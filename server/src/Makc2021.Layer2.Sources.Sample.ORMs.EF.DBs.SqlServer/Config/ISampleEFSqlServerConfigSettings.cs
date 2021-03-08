//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.DBs.SqlServer.Config
{
    /// <summary>
    /// Источник "Sample". ORM "Entity Framework". База данных "Microsoft SQL Server". Настройки. Интерфейс.
    /// </summary>
    public interface ISampleEFSqlServerConfigSettings
    {
        #region Properties

        /// <summary>
        /// Строка подключения.
        /// </summary>
        string ConnectionString { get; }

        #endregion Properties
    }
}