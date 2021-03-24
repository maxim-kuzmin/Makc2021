// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer1.Common
{
    /// <summary>
    /// Общий модуль.
    /// Используется как базовый класс всех модулей - классов,
    /// предназначенных для подготовки к работе различных частей приложения.    
    /// </summary>
    public abstract class CommonModule
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public abstract void ConfigureServices(IServiceCollection services);

        /// <summary>
        /// Получить не импортированные типы.
        /// </summary>
        /// <param name="allExports">Все экспортированные типы.</param>
        /// <returns>Не импортированные типы.</returns>
        public IEnumerable<Type> GetNotImportedtTypes(HashSet<Type> allExports)
        {
            return GetImports().Where(x => !allExports.Contains(x));
        }

        /// <summary>
        /// Получить экспортированные типы.
        /// </summary>
        /// <returns>Экспортированные типы.</returns>
        public abstract IEnumerable<Type> GetExports();

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Получить импортированные типы.
        /// </summary>
        /// <returns>Импортированные типы.</returns>
        protected abstract IEnumerable<Type> GetImports();

        #endregion Protected methods
    }
}
