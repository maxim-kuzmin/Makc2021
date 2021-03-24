// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Linq;
using Makc2021.Layer1.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer5.Apps.WebAPI
{
    /// <summary>
    /// Модуль.
    /// </summary>
    public class Module
    {
        #region Properties

        /// <summary>
        /// Модуль слоя "Layer1". 
        /// </summary>
        private Layer1.Module Layer1Module { get; } = new();

        /// <summary>
        /// Модуль клиента "Sample" слоя "Layer3".
        /// </summary>
        private Layer3.Sample.Clients.SqlServer.EF.ClientModule Layer3SampleClientModule { get; } = new();

        /// <summary>
        /// Модуль сопоставителя "Sample" слоя "Layer3". 
        /// </summary>
        private Layer3.Sample.Mappers.EF.MapperModule Layer3SampleMapperModule { get; } = new();

        /// <summary>
        /// Модуль домена "DummyMain" слоя "Layer4".
        /// </summary>
        private Layer4.Domains.DummyMain.DomainModule Layer4DummyMainDomainModule { get; } = new();

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public Module()
        {
            var allExports = new[]
                {
                    typeof(ILogger)
                }
                .Union(Layer1Module.GetExports())
                .Union(Layer3SampleClientModule.GetExports())
                .Union(Layer3SampleMapperModule.GetExports())
                .Union(Layer4DummyMainDomainModule.GetExports())
                .ToHashSet();

            var notImportedTypes = Layer1Module.GetNotImportedtTypes(allExports)
                .Union(Layer3SampleClientModule.GetNotImportedtTypes(allExports))
                .Union(Layer3SampleMapperModule.GetNotImportedtTypes(allExports))
                .Union(Layer4DummyMainDomainModule.GetNotImportedtTypes(allExports));

            if (notImportedTypes.Any())
            {
                notImportedTypes.ThrowExceptionForNotImportedTypes();
            }
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Настроить.
        /// </summary>
        public void Configure()
        {
        }

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            Layer1Module.ConfigureServices(services);
            Layer3SampleClientModule.ConfigureServices(services);
            Layer3SampleMapperModule.ConfigureServices(services);
            Layer4DummyMainDomainModule.ConfigureServices(services);            
        }

        #endregion Protected methods
    }
}
