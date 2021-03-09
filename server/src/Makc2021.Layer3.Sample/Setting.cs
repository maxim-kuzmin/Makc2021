//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample
{
    /// <inheritdoc/>
    public class Setting : Layer2.Setting<Defaults>
    {
        #region Constructors

        /// <inheritdoc/>
        public Setting(Defaults defaults, string dbTable, string dbSchema = null)
            : base(defaults, dbTable, dbSchema)
        {
        }

        #endregion Constructors
    }
}
