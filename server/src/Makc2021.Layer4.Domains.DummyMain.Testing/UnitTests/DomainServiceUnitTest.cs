// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using AutoFixture.Xunit2;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
using Makc2021.Layer4.Domains.DummyMain.Queries.List.Get;
using Xunit;

namespace Makc2021.Layer4.Domains.DummyMain.Testing.UnitTests
{
    /// <summary>
    /// Модульный тест сервиса домена.
    /// </summary>
    public class DomainServiceUnitTest : UnitTest
    {
        #region Constructors

        /// <inheritdoc/>
        public DomainServiceUnitTest(UnitTestFixtures fixtures)
            : base(fixtures)
        {
        }

        #endregion Constructors

        #region Public methods

        [Theory(DisplayName = "Получить элемент из DomainService")]
        [Trait("DomainService", "Получить элемент")]
        [AutoData]
        public void GetItem(DomainItemGetQueryInput input)
        {
            Assert.NotNull(input);
        }

        [Theory(DisplayName = "Получить список из DomainService")]
        [Trait("DomainService", "Получить список")]
        [AutoData]
        public void GetList(DomainListGetQueryInput input)
        {
            Assert.NotNull(input);
        }

        #endregion Public methods
    }
}
