// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;
using Makc2021.Layer3.Sql.Sample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer3.Sql.Sample.Mappers.EF.Db
{
    /// <summary>
    /// Фабрика базы данных сопоставителя.
    /// </summary>
    public abstract class MapperDbFactory :
        Layer2.Sql.Mappers.EF.Db.MapperDbFactory<EntitiesOptions>,
        IMapperDbFactory
    {
        #region Properties

        /// <summary>
        /// Опции.
        /// </summary>
        public DbContextOptions<MapperDbContext> Options { get; private set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public MapperDbFactory()
            : base()
        {
            Initialize(null, null, null);
        }

        /// <inheritdoc/>
        public MapperDbFactory(
            string connectionString,
            EntitiesOptions entitiesSettings,
            CommonEnvironment environment,
            ILogger logger,
            LogLevel logLevel
            )
            : base(
                connectionString,
                entitiesSettings,
                environment,
                logger,
                logLevel
                )
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public abstract MapperDbContext CreateDbContext();

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void Initialize(
            string connectionString,
            EntitiesOptions entitiesSettings,
            CommonEnvironment environment
            )
        {
            base.Initialize(connectionString, entitiesSettings, environment);

            Options = CreateDbContextOptions();
        }

        #endregion Protected methods

        #region Private methods

        private DbContextOptions<MapperDbContext> CreateDbContextOptions()
        {
            DbContextOptionsBuilder<MapperDbContext> builder = new();

            BuildDbContextOptions(builder);

            return builder.Options;
        }

        #endregion Private methods
    }
}
