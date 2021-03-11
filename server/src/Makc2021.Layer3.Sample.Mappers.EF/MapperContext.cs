//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Mappers.EF.Config;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Контекст ORM.
    /// </summary>
    public class MapperContext
    {
        #region Properties

        /// <summary>
        /// Конфигурационные настройки.
        /// </summary>
        public IMapperConfigSettings ConfigSettings { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешние зависимости.</param>
        public MapperContext(IMapperConfigSettings configSettings, MapperExternals externals)
        {
            ConfigSettings = configSettings;
        }

        #endregion Constructo
    }
}
