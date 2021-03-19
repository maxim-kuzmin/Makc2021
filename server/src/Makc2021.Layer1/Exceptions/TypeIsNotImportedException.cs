// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;

namespace Makc2021.Layer1.Exceptions
{
    /// <summary>
    /// Исключение, возникающее в случае, если тип не импортирован.
    /// </summary>
    public class TypeIsNotImportedException : Exception
    {
        #region Constructors

        public TypeIsNotImportedException(Type type)
            : base($"{type} is not ready")
        {
        }

        #endregion Constructors
    }
}
