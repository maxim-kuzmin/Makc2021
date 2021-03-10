//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.ORMs.EF.Config
{
    /// <summary>
    /// ORM "Entity Framework". Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface IEFConfigSettings
    {
        #region Properties

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        int DbCommandTimeout { get; }

        #endregion Properties
    }
}