﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Localization;

namespace Makc2021.Layer4.Sql.Domains.DummyMain
{
    /// <summary>
    /// Ресурс домена.
    /// </summary>
    public class DomainResource : IDomainResource
    {
        #region Properties

        private IStringLocalizer<DomainResource> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public DomainResource(IStringLocalizer<DomainResource> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public string GetItemGetQueryName()
        {
            return Localizer["@@ItemGetQueryName"];
        }

        /// <inheritdoc/>
        public string GetListGetQueryName()
        {
            return Localizer["@@ListGetQueryName"];
        }

        #endregion Public methods
    }
}
