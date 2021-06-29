// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Xunit;

namespace Makc2021.Layer4.Domains.DummyMain.Testing
{
    /// <summary>
    /// Юнит-тест.
    /// </summary>
    public class UnitTest : IClassFixture<UnitTestFixtures>
    {
        #region Properties

        /// <summary>
        /// Оснастки.
        /// </summary>
        protected UnitTestFixtures Fixtures { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="fixtures">Оснастки.</param>
        public UnitTest(UnitTestFixtures fixtures)
        {
            Fixtures = fixtures;
        }

        #endregion Constructors
    }
}