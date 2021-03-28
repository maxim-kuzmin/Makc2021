// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Интерфейс сервиса сопоставителя.
    /// </summary>
    public interface IMapperService
    {
        #region Methods

        /// <summary>
        /// Мигрировать базу данных.
        /// </summary>
        Task MigrateDatabase();

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        Task SeedTestData();

        #endregion Methods
    }
}
