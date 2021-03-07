//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.DBs.SqlServer.Filestream
{
    /// <summary>
    /// База данных "Microsoft SQL Server". Файловый поток. Доступ.
    /// </summary>
    public enum SqlServerFilestreamAccess : uint
    {
        /// <summary>
        /// Прочитать.
        /// </summary>
        Read,
        /// <summary>
        /// Записать.
        /// </summary>
        Write,
        /// <summary>
        /// Прочитать и записать.
        /// </summary>
        ReadWrite
    }
}
