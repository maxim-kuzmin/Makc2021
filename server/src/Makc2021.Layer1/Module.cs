// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Makc2021.Layer1.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Makc2021.Layer1
{
    public abstract class Module
    {
        #region Fields

        private readonly HashSet<Type> _imports;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="imports">Импортируемые типы.</param>
        public Module(HashSet<Type> imports)
        {
            _imports = imports;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public abstract void ConfigureServices(IServiceCollection services);

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Выбросить исключение, если тип не импортирован.
        /// </summary>
        /// <param name="type">Тип.</param>
        protected void ThrowExceptionIfTypeIsNotImported(Type type)
        {
            if (!_imports.Contains(type))
            {
                throw new TypeIsNotImportedException(type);
            }
        }

        #endregion Protected methods
    }
}
