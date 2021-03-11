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
        /// ORM.
        /// </summary>
        public MapperModule Mapper { get; } = new();

        /// <summary>
        /// ORM клиента.
        /// </summary>
        public ClientMapperModule ClientMapper { get; } = new();

        #endregion Properties
    }
}
