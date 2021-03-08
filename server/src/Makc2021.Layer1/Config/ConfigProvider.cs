//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer1.Config
{
    /// <summary>
    /// Конфигурация. Поставщик.
    /// </summary>
    /// <typeparam name="TSettings">Тип настроек.</typeparam>
    public abstract class ConfigProvider<TSettings>
    {
        #region Properties

        /// <summary>
        /// Настройки.
        /// </summary>
        public TSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public ConfigProvider(TSettings settings)
        {
            Settings = settings;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public abstract void Load();

        /// <inheritdoc/>
        public abstract void Save();

        #endregion Public methods
    }
}
