//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.Mappers.EF.Config
{
    /// <summary>
    /// Интерфейс настроек конфигурации ORM.
    /// </summary>
    public interface IMapperConfigSettings
    {
        #region Properties

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        int DbCommandTimeout { get; }

        #endregion Properties
    }
}