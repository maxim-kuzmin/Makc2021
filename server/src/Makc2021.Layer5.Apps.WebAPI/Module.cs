// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Layer1 = Makc2021.Layer1;
using SampleClient = Makc2021.Layer3.Sample.Clients.SqlServer.EF;
using SampleMapper = Makc2021.Layer3.Sample.Mappers.EF;

namespace Makc2021.Layer5.Apps.WebAPI
{
    /// <summary>
    /// Модуль.
    /// </summary>
    public class Module : Layer1.Module
    {
        #region Properties

        /// <summary>
        /// Ресурсы.
        /// </summary>
        private Layer1::Resources.Module Resources { get; }

        /// <summary>
        /// Клиент "Sample".
        /// </summary>
        private SampleClient::ClientModule SampleClient { get; }

        /// <summary>
        /// Сопоставитель "Sample".
        /// </summary>
        private SampleMapper::MapperModule SampleMapper { get; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        private Module(HashSet<Type> imports)
            : base(imports)
        {
            Resources = new(imports);
            SampleClient = new(imports);
            SampleMapper = new(imports);
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        public void Configure()
        {
        }

        /// <inheritdoc/>
        public sealed override void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => { options.ResourcesPath = "ResourceFiles"; });

            services.AddSingleton(new Layer1::Environment());            

            Resources.ConfigureServices(services);
            SampleClient.ConfigureServices(services);
            SampleMapper.ConfigureServices(services);            
        }

        /// <summary>
        /// Создать.
        /// </summary>
        /// <returns>Модуль.</returns>
        public static Module Create()
        {
            var imports = new[]
            {
                typeof(IStringLocalizer),
                typeof(Layer1.Environment)
            }
            .Union(Layer1::Resources.Module.GetExports())
            .Union(SampleClient::ClientModule.GetExports())
            .Union(SampleMapper::MapperModule.GetExports())
            .ToHashSet();

            return new Module(imports);
        }

        #endregion Public methods
    }
}
