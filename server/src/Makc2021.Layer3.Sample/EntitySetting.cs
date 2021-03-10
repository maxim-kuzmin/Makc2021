//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample
{
    /// <inheritdoc/>
    public class EntitySetting : Layer2.EntitySetting<Defaults>
    {
        #region Constructors

        /// <inheritdoc/>
        public EntitySetting(Defaults defaults, string dbTable, string dbSchema = null)
            : base(defaults, dbTable, dbSchema)
        {
        }

        #endregion Constructors
    }
}
