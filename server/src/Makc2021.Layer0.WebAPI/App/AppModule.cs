//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.ORMs.EF;
using Makc2021.Layer3.Sample.ORMs.EF.DBs.SqlServer;

namespace Makc2021.Layer0.WebAPI.App
{
    /// <summary>
    /// Приложение. Модуль.
    /// </summary>
    public class AppModule
    {
        #region Properties

        /// <summary>
        /// ORM "Entity Framework".
        /// </summary>
        public EFModule EF { get; } = new();

        /// <summary>
        /// ORM "Entity Framework". База данных "Microsoft SQL Server".
        /// </summary>
        public EFSqlServerModule EFSqlServer { get; } = new();

        #endregion Properties
    }
}
