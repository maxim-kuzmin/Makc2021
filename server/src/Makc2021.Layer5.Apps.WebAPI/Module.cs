// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Makc2021.Layer1.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer5.Apps.WebAPI
{
    /// <summary>
    /// Модуль.
    /// </summary>
    public class Module : CommonModule
    {
        #region Properties

        /// <summary>
        /// Модуль слоя "Layer1". 
        /// </summary>
        private Layer1.Module Layer1Module { get; }

        /// <summary>
        /// Модуль клиента "Sample" слоя "Layer3".
        /// </summary>
        private Layer3.Sample.Clients.SqlServer.EF.ClientModule Layer3SampleClientModule { get; }

        /// <summary>
        /// Модуль сопоставителя "Sample" слоя "Layer3". 
        /// </summary>
        private Layer3.Sample.Mappers.EF.MapperModule Layer3SampleMapperModule { get; }

        /// <summary>
        /// Модуль домена "DummyMain" слоя "Layer4".
        /// </summary>
        private Layer4.Domains.DummyMain.DomainModule Layer4DummyMainDomainModule { get; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        private Module(HashSet<Type> imports)
            : base(imports)
        {
            Layer1Module = new(imports);
            Layer3SampleClientModule = new(imports);
            Layer3SampleMapperModule = new(imports);
            Layer4DummyMainDomainModule = new(imports);            
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
            services.AddLocalization(options =>
            {
                InitLocalizationOptions(options); 
            });

            services.AddSingleton(new CommonEnvironment());

            Layer1Module.ConfigureServices(services);
            Layer3SampleClientModule.ConfigureServices(services);
            Layer3SampleMapperModule.ConfigureServices(services);
            Layer4DummyMainDomainModule.ConfigureServices(services);            
        }

        /// <summary>
        /// Создать.
        /// </summary>
        /// <returns>Модуль.</returns>
        public static Module Create()
        {
            var imports = new[]
            {
                typeof(ILogger),
                typeof(IStringLocalizer),
                typeof(CommonEnvironment)
            }
            .Union(Layer1.Module.GetExports())
            .Union(Layer3.Sample.Clients.SqlServer.EF.ClientModule.GetExports())
            .Union(Layer3.Sample.Mappers.EF.MapperModule.GetExports())
            .Union(Layer4.Domains.DummyMain.DomainModule.GetExports())            
            .ToHashSet();

            return new Module(imports);
        }

        #endregion Public methods
    }
}
