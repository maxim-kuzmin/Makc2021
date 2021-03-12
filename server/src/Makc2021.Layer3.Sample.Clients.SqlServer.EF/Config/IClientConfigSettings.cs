//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config
{
    /// <summary>
    /// Интерфейс настроек конфигурации клиента.
    /// </summary>
    public interface IClientConfigSettings
    {
        #region Properties

        /// <summary>
        /// Строка подключения.
        /// </summary>
        string ConnectionString { get; }

        #endregion Properties
    }
}