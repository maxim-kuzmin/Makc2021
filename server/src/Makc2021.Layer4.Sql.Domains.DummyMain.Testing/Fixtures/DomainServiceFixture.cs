// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Mappers.EF.Db;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Testing.Fixtures
{
    /// <summary>
    /// Оснастка сервиса домена.
    /// </summary>
    public class DomainServiceFixture
    {
        #region Properties

        /// <summary>
        /// Теннстируемое.
        /// </summary>
        public IDomainService Testable { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dbFactory">Фабрика базы данных.</param>
        public DomainServiceFixture(IMapperDbFactory dbFactory)
        {
            Testable = new DomainService(dbFactory);
        }

        #endregion Constructors
    }
}
