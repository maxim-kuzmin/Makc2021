// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Mappers.EF.Db;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Интерфейс сервиса сопоставителя.
    /// </summary>
    public interface IMapperService
    {
        #region Methods

        /// <summary>
        /// Создать контекст базы данных.
        /// </summary>
        /// <returns>Контекст базы данных.</returns>
        MapperDbContext CreateDbContext();

        #endregion Methods
    }
}
