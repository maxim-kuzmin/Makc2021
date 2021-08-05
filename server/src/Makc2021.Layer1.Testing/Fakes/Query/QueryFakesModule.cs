// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoFixture;
using Makc2021.Layer1.Common;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Makc2021.Layer1.Testing.Fakes.Query
{
    public class QueryFakesModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => CreateQueryResourceFake());
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IQueryResourceFake)
            };
        }

        #endregion Public methods

        #region Private methods

        private static IQueryResourceFake CreateQueryResourceFake()
        {
            var mock = new Mock<IQueryResourceFake>();

            mock.Setup(x => x.GetErrorMessageForDefault())
                .Returns(nameof(IQueryResourceFake.GetErrorMessageForDefault));

            mock.Setup(x => x.GetErrorMessageForInvalidInput(It.IsAny<IEnumerable<string>>()))
                .Returns((IEnumerable<string> invalidProperties) => {
                    string str = string.Join(",", invalidProperties);

                    return $"{nameof(IQueryResourceFake.GetErrorMessageForInvalidInput)}: {str}";
                    });

            mock.Setup(x => x.GetTitleForError())
                .Returns(nameof(IQueryResourceFake.GetTitleForError));

            mock.Setup(x => x.GetTitleForInput())
                .Returns(nameof(IQueryResourceFake.GetTitleForInput));

            mock.Setup(x => x.GetTitleForQueryCode())
                .Returns(nameof(IQueryResourceFake.GetTitleForQueryCode));

            mock.Setup(x => x.GetTitleForResult())
                .Returns(nameof(IQueryResourceFake.GetTitleForResult));

            mock.Setup(x => x.GetTitleForStart())
                .Returns(nameof(IQueryResourceFake.GetTitleForStart));

            mock.Setup(x => x.GetTitleForSuccess())
                .Returns(nameof(IQueryResourceFake.GetTitleForSuccess));

            var builder = Helper.CreateFakeBuilder<IQueryResourceFake>();

            return builder.FromSeed(x => mock.Object).Create();
        }

        #endregion Private methods
    }
}
