//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Makc2021.Layer1.Config.Providers;

namespace Makc2021.Layer3.Sample.Clients.SqlServer.EF.Config
{
    /// <summary>
    /// Поставщик конфигурации клиента.
    /// </summary>
    public class ClientConfigProvider : JsonConfigProvider<ClientConfigSettings>
    {
        #region Constructors

        /// <inheritdoc/>
        public ClientConfigProvider(
            ClientConfigSettings settings,
            string filePath,
            Environment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
