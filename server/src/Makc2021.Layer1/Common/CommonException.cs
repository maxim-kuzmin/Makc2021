// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2021.Layer1.Common
{
    /// <summary>
    /// Общее исключение.
    /// </summary>
    public class CommonException : Exception
    {
        #region Constructors

        /// <inheritdoc/>
        public CommonException(string message)
            : base(message)
        {
        }

        #endregion Constructors
    }
}
