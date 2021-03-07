//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.Sources.Sample
{
    /// <summary>
    /// Источник "Sample". Настройка.
    /// </summary>
    public class SampleSetting : Setting<SampleDefaults>
    {
        #region Constructors

        /// <inheritdoc/>
        public SampleSetting(SampleDefaults defaults, string dbTable, string dbSchema = null)
            : base(defaults, dbTable, dbSchema)
        {
        }

        #endregion Constructors
    }
}
