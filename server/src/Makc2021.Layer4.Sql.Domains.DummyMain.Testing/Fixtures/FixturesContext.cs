// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Testing.Fixtures
{
    /// <summary>
    /// Контекст оснасток.
    /// </summary>
    public class FixturesContext : IDisposable
    {
        #region Fields

        private bool _disposedValue;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Сервис домена.
        /// </summary>
        public DomainServiceFixture DomainService { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public FixturesContext()
        {
            Configurator.UseServices();

            DomainService = Configurator.ServiceProvider.GetRequiredService<DomainServiceFixture>();
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitTestFixtures()
        // {
        // // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        // Dispose(disposing: false);
        // }

        #endregion Constructors

        #region Public methods

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Public methods

        #region Protected methods

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        #endregion Protected methods
    }
}

