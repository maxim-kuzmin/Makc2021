// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Microsoft.Extensions.Localization;

namespace Makc2021.Layer1.Common
{
    /// <summary>
    /// Общий ресурс.
    /// </summary>
    public class CommonResource : ICommonResource
    {
        #region Properties

        private IStringLocalizer<CommonResource> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public CommonResource(IStringLocalizer<CommonResource> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public string GetTypeIsNotImportedErrorMessage(Type type)
        {
            string key = string.Format("Тип '{0}' не импортирован", type.FullName);

            return Localizer[key];
        }

        #endregion Public methods
    }
}
