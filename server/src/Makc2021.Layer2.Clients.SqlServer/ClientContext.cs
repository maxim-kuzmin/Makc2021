//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.Clients.SqlServer
{
    /// <summary>
    /// Контекст клиента.
    /// </summary>
    public class ClientContext
    {
        #region Properties

        /// <summary>
        /// Поставщик.
        /// </summary>
        public IProvider Provider { get; private set; } = new ClientProvider();

        #endregion Properties
    }
}
