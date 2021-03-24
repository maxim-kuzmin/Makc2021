// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer1.Common;

namespace Makc2021.Layer5.Apps.WebAPI
{
    /// <summary>
    /// Конфигуратор.
    /// </summary>
    public class Configurator : CommonConfigurator
    {
        #region Properties

        private Layer1.Module Layer1Module { get; } = new();

        private Layer3.Sample.Clients.SqlServer.EF.ClientModule Layer3SampleClientModule { get; } = new();

        private Layer3.Sample.Mappers.EF.MapperModule Layer3SampleMapperModule { get; } = new();

        private Layer4.Domains.DummyMain.DomainModule Layer4DummyMainDomainModule { get; } = new();

        private Module Layer5Module { get; } = new();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        public void Configure()
        {
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IEnumerable<CommonModule> GetModules()
        {
            return new CommonModule[]
                {
                    Layer1Module,
                    Layer3SampleClientModule,
                    Layer3SampleMapperModule,
                    Layer4DummyMainDomainModule,
                    Layer5Module
                };
        }

        #endregion Protected methods
    }
}
