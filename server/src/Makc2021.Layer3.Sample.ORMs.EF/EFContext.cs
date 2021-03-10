//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.ORMs.EF.Config;

namespace Makc2021.Layer3.Sample.ORMs.EF
{
    public class EFContext
    {
        #region Properties

        /// <summary>
        /// Конфигурационные настройки.
        /// </summary>
        public IEFConfigSettings ConfigSettings { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешнее.</param>
        public EFContext(IEFConfigSettings configSettings, EFExternals externals)
        {
            ConfigSettings = configSettings;
        }

        #endregion Constructo
    }
}
