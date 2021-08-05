// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Makc2021.Layer1.Query;

namespace Makc2021.Layer1.Testing.Fakes.Query
{
    /// <summary>
    /// Подделка обработчика запроса.
    /// </summary>
    public class QueryHandlerFake : IQueryHandler
    {
        #region Properties

        /// <summary>
        /// Исключение.
        /// </summary>
        public Exception Exception { get; private set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public void OnError(Exception exception)
        {
            Exception = exception;
        }

        #endregion Public methods
    }
}
