//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Mappers.EF;
using Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer;

namespace Makc2021.Layer0.WebAPI.App
{
    /// <summary>
    /// Модуль приложения.
    /// </summary>
    public class AppModule
    {
        #region Properties

        /// <summary>
        /// ORM "Entity Framework".
        /// </summary>
        public MapperModule EF { get; } = new();

        /// <summary>
        /// ORM "Entity Framework". База данных "Microsoft SQL Server".
        /// </summary>
        public ClientMapperModule EFSqlServer { get; } = new();

        #endregion Properties
    }
}
