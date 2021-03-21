// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.Mappers.EF.Db
{
    /// <summary>
    /// Интерфейс фабрики базы данных сопоставителя.
    /// </summary>
    public interface IMapperDbFactory
    {
        #region Properties

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        EntitiesSettings EntitiesSettings { get; }

        /// <summary>
        /// Опции.
        /// </summary>
        DbContextOptions<MapperDbContext> Options { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Создать контекст базы данных.
        /// </summary>
        /// <returns>Контекст базы данных.</returns>
        MapperDbContext CreateDbContext();

        #endregion Methods
    }
}
