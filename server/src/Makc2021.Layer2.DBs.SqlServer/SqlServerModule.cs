﻿//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2021.Layer2.DBs.SqlServer
{
    /// <summary>
    /// База данных "Microsoft SQL Server". Модуль.
    /// </summary>
    public class SqlServerModule : IModule
    {
        #region Properties

        /// <summary>
        /// Контекст.
        /// </summary>
        public SqlServerContext Context { get; private set; } = new SqlServerContext();

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

        private SqlServerContext GetContext(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService<SqlServerContext>();
        }

        #endregion Private methods
    }
}