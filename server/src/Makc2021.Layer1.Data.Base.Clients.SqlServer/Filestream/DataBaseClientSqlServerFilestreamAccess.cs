//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer1.Data.Base.Clients.SqlServer.Filestream
{
    /// <summary>
    /// Данные. Основа. Клиенты. SQL Server. Файловый поток. Доступ.
    /// </summary>
    public enum DataBaseClientSqlServerFilestreamAccess : uint
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
