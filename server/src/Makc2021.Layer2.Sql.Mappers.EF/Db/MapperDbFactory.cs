// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer2.Sql.Mappers.EF.Db
{
    /// <summary>
    /// Фабрика базы данных сопоставителя.
    /// </summary>
    /// <typeparam name="TEntitiesOptions">Тип параметров сущностей.</typeparam>
    public abstract class MapperDbFactory<TEntitiesOptions> : IMapperDbFactory<TEntitiesOptions>
    {
        #region Properties

        private LogLevel LogLevel { get; }

        /// <summary>
        /// Строка подключения.
        /// </summary>
        protected string ConnectionString { get; private set; }

        /// <summary>
        /// Окружение.
        /// </summary>
        protected CommonEnvironment Environment { get; private set; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger Logger { get; private set; }

        /// <inheritdoc/>
        public TEntitiesOptions EntitiesOptions { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MapperDbFactory()
        {
            Initialize(null, default, null);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        /// <param name="entitiesOptions">Параметры сущностей.</param>
        /// <param name="environment">Окружение.</param>
        /// <param name="logger">Регистратор.</param>
        /// <param name="logLevel">Уровень логирования.</param>
        public MapperDbFactory(
            string connectionString,
            TEntitiesOptions entitiesOptions,
            CommonEnvironment environment,
            ILogger logger,
            LogLevel logLevel
            )
        {
            Logger = logger;
            LogLevel = logLevel;

            Initialize(connectionString, entitiesOptions, environment);
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Построить опции контекста базы данных.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        protected virtual void BuildDbContextOptions(DbContextOptionsBuilder builder)
        {
            if (Logger != null)
            {
                builder.LogTo(
                    message =>
                    {
                        switch (LogLevel)
                        {
                            case LogLevel.Information:
                                Logger.LogInformation(message);
                                break;
                            case LogLevel.Trace:
                                Logger.LogTrace(message);
                                break;
                            case LogLevel.Debug:
                            default:
                                Logger.LogDebug(message);
                                break;
                        }
                    },
                    new[]
                    {
                        RelationalEventId.CommandExecuted/*,
                        RelationalEventId.CommandExecuting*/
                    });
            }
        }

        /// <summary>
        /// Создать строку подключения.
        /// </summary>
        /// <returns>Строка подключения.</returns>
        protected abstract string CreateConnectionString();

        /// <summary>
        /// Создать настройки сущностей.
        /// </summary>
        /// <returns>Настройки сущностей.</returns>
        protected abstract TEntitiesOptions CreateEntitiesOptions();

        /// <summary>
        /// Инициализировать.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        /// <param name="entitiesOptions">Параметры сущностей.</param>
        /// <param name="environment">Окружение.</param>
        protected virtual void Initialize(
            string connectionString,
            TEntitiesOptions entitiesOptions,
            CommonEnvironment environment
            )
        {
            Environment = environment ?? new();
            EntitiesOptions = entitiesOptions ?? CreateEntitiesOptions();
            ConnectionString = connectionString ?? CreateConnectionString();
        }

        #endregion Protected methods
    }
}
