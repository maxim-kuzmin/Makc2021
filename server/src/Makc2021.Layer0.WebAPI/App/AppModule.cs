// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using SampleClient = Makc2021.Layer3.Sample.Clients.SqlServer.EF;
using SampleMapper = Makc2021.Layer3.Sample.Mappers.EF;

namespace Makc2021.Layer0.WebAPI.App
{
    /// <summary>
    /// Модуль приложения.
    /// </summary>
    public class AppModule
    {
        #region Properties

        /// <summary>
        /// ORM "Sample".
        /// </summary>
        public SampleMapper::MapperModule SampleMapper { get; } = new();

        /// <summary>
        /// Клиент "Sample".
        /// </summary>
        public SampleClient::ClientModule SampleClient { get; } = new();

        #endregion Properties
    }
}
