//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer1.Config.Providers;

namespace Makc2021.Layer3.Sample.Mappers.EF.Config
{
    /// <summary>
    /// Поставщик конфигурации ORM.
    /// </summary>
    public class MapperConfigProvider : JsonConfigProvider<MapperConfigSettings>
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperConfigProvider(MapperConfigSettings settings, string filePath, Environment environment)
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
