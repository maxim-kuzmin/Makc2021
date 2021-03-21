// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer2.Common;

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
        public ICommonProvider Provider { get; } = new ClientProvider();

        #endregion Properties
    }
}
