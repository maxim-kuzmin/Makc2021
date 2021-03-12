// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

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
        public IProvider Provider { get; } = new ClientProvider();

        #endregion Properties
    }
}
