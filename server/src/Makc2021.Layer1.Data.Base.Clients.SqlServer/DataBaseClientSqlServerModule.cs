//Author Maxim Kuzmin//makc//

using Makc2021.Layer1.Base.Common;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2021.Layer1.Data.Base.Clients.SqlServer
{
    /// <summary>
    /// Данные. Основа. Клиенты. SQL Server. Модуль.
    /// </summary>
    public class DataBaseClientSqlServerModule : IBaseCommonModule
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public DataBaseClientSqlServerContext Context { get; private set; } = new DataBaseClientSqlServerContext();

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(x => GetContext(x).Provider);
        }

        #endregion Public methods

        #region Private methods

        private DataBaseClientSqlServerContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<DataBaseClientSqlServerContext>();
        }

        #endregion Private methods
    }
}