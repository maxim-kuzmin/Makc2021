// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Dsl;

namespace Makc2021.Layer1.Testing
{
    /// <summary>
    /// Помощник.
    /// </summary>
    public static class Helper
    {
        #region Public methods

        /// <summary>
        /// Создать подделку.
        /// </summary>
        /// <typeparam name="T">Подделываемый тип.</typeparam>
        /// <returns>Подделка.</returns>
        public static T CreateFake<T>()
        {
            return CreateFixture().Create<T>();
        }

        /// <summary>
        /// Создать подделки.
        /// </summary>
        /// <typeparam name="T">Подделываемый тип.</typeparam>
        /// <param name="count">Количество.</param>
        /// <returns>Подделки.</returns>
        public static IEnumerable<T> CreateFakes<T>(int count = -1)
        {
            return count < 0 ? CreateFixture().CreateMany<T>() : CreateFixture().CreateMany<T>(count);
        }

        /// <summary>
        /// Создать построитель подделок.
        /// </summary>
        /// <typeparam name="T">Подделываемый тип.</typeparam>
        /// <returns>Построитель подделок.</returns>
        public static ICustomizationComposer<T> CreateFakeBuilder<T>()
        {
            return CreateFixture().Build<T>();
        }

        #endregion Public methods

        #region Private methods

        private static IFixture CreateFixture()
        {
            return new Fixture().Customize(new AutoMoqCustomization
            {
                ConfigureMembers = true,
                GenerateDelegates = true
            }).Customize(new SupportMutableValueTypesCustomization());
        }

        #endregion Private methods
    }
}
