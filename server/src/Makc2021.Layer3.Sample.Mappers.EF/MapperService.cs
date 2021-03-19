// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Mappers.EF.Config;
using Makc2021.Layer3.Sample.Mappers.EF.Db;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Интерфейс сервиса сопоставителя.
    /// </summary>
    public class MapperService : IMapperService
    {
        #region Properties

        private IMapperConfigSettings AppConfigSettings { get; }

        private IMapperDbFactory AppDbFactory { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appConfigSettings">Конфигурационные настройки.</param>
        /// <param name="appDbFactory">Фабрика базы данных.</param>
        public MapperService(IMapperConfigSettings appConfigSettings, IMapperDbFactory appDbFactory)
        {
            AppConfigSettings = appConfigSettings;
            AppDbFactory = appDbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public MapperDbContext CreateDbContext()
        {
            var result = AppDbFactory.CreateDbContext();

            int dbCommandTimeout = AppConfigSettings.DbCommandTimeout;

            if (dbCommandTimeout < 1)
            {
                dbCommandTimeout = 3600;
            }

            result.Database.SetCommandTimeout(dbCommandTimeout);

            return result;
        }

        #endregion Public methods
    }
}
