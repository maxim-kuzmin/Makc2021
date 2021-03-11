//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer1.Config
{
    /// <summary>
    /// Поставщик конфигурации.
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

        /// <summary>
        /// Загрузить.
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// Сохранить.
        /// </summary>
        public abstract void Save();

        #endregion Public methods
    }
}
