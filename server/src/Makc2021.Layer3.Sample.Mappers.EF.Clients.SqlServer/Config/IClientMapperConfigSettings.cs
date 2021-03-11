//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.Mappers.EF.Clients.SqlServer.Config
{
    /// <summary>
    /// Интерфейс настроек конфигурации ORM клиента.
    /// </summary>
    public interface IClientMapperConfigSettings
    {
        #region Properties

        /// <summary>
        /// Строка подключения.
        /// </summary>
        string ConnectionString { get; }

        #endregion Properties
    }
}