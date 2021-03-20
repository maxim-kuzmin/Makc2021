// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Resources.Errors;

namespace Makc2021.Layer1.Query.Exceptions
{
    /// <summary>
    /// Исключение, возникающее в случае наличия недействительных свойств.
    /// </summary>
    public class InvalidPropertiesException : Exception
    {
        #region Properties

        /// <summary>
        /// Список свойств с недействительными значениями.
        /// </summary>
        public List<string> InvalidProperties { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resource">Ресурс.</param>
        /// <param name="invalidProperties">Список свойств с недействительными значениями.</param>
        public InvalidPropertiesException(IErrorsResource resource, List<string> invalidProperties)
            : base(resource.GetForInvalidProperties(invalidProperties))
        {
            InvalidProperties = invalidProperties;
        }

        #endregion Constructors
    }
}
