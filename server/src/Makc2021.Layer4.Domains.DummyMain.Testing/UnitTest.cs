// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer4.Domains.DummyMain.Testing.Fixtures;
using Xunit;

namespace Makc2021.Layer4.Domains.DummyMain.Testing
{
    /// <summary>
    /// Юнит-тест.
    /// </summary>
    public class UnitTest : IClassFixture<FixturesContext>
    {
        #region Properties

        /// <summary>
        /// Оснастки.
        /// </summary>
        protected FixturesContext Fixtures { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="fixtures">Оснастки.</param>
        public UnitTest(FixturesContext fixtures)
        {
            Fixtures = fixtures;
        }

        #endregion Constructors
    }
}