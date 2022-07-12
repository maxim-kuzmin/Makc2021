// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoFixture;
using Makc2021.Layer1.Common;
using Makc2021.Layer1.Testing;
using Makc2021.Layer3.Sql.Sample.Mappers.EF.Db;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Testing.Fakes
{
    /// <summary>
    /// Модуль подделок.
    /// </summary>
    public class FakesModule : CommonModule
    {
        #region Public methods

        /// <inheritdoc/>
        public override void ConfigureServices(IServiceCollection services)
        {           
            services.AddTransient(x => CreateDomainResourceFake());
            services.AddTransient(x => CreateMapperDbFactory());
        }

        /// <inheritdoc/>
        public sealed override IEnumerable<Type> GetExports()
        {
            return new[]
            {
                typeof(IDomainResourceFake),
                typeof(IMapperDbFactory),                
            };
        }

        #endregion Public methods

        #region Private methods

        private static IDomainResourceFake CreateDomainResourceFake()
        {
            var mock = new Mock<IDomainResourceFake>();

            mock.Setup(x => x.GetItemGetQueryName())
                .Returns(nameof(IDomainResourceFake.GetItemGetQueryName));

            mock.Setup(x => x.GetListGetQueryName())
                .Returns(nameof(IDomainResourceFake.GetListGetQueryName));

            var builder = Helper.CreateFakeBuilder<IDomainResourceFake>();

            return builder.FromSeed(x => mock.Object).Create();
        }

        private static IMapperDbFactory CreateMapperDbFactory()
        {
            var result = new Mock<IMapperDbFactory>();

            return result.Object;
        }

        #endregion Private methods
    }
}
