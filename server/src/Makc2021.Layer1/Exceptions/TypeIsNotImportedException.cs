// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Exceptions
{
    /// <summary>
    /// Исключение, возникающее в случае, если тип не импортирован.
    /// </summary>
    public class TypeIsNotImportedException : CommonException
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resource">Ресурс.</param>
        /// <param name="type">Тип.</param>
        public TypeIsNotImportedException(IErrorsResource resource, Type type)
            : base(resource.GetForTypeIsNotImported(type))
        {
        }

        #endregion Constructors
    }
}
