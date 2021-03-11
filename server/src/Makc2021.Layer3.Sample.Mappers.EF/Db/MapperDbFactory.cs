//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.Mappers.EF.Db
{
    /// <summary>
    /// Фабрика базы данных ORM.
    /// </summary>
    public abstract class MapperDbFactory : IMapperDbFactory
    {
        #region Properties

        /// <summary>
        /// Строка подключения.
        /// </summary>
        protected string ConnectionString { get; private set; }

        /// <summary>
        /// Окружение.
        /// </summary>
        protected Environment Environment { get; private set; }

        /// <inheritdoc/>
        public DbContextOptions<MapperDbContext> Options { get; private set; }

        /// <inheritdoc/>
        public EntitiesSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MapperDbFactory()
        {
            Initialize(null, null, null);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        /// <param name="settings">Настройки.</param>
        /// <param name="environment">Окружение.</param>
        public MapperDbFactory(string connectionString, EntitiesSettings settings, Environment environment)
        {
            Initialize(connectionString, settings, environment);
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public abstract MapperDbContext CreateDbContext();

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать строку подключения.
        /// </summary>
        /// <returns>Строка подключения.</returns>
        protected abstract string CreateConnectionString();

        /// <summary>
        /// Создать настройки.
        /// </summary>
        /// <returns>Настройки.</returns>
        protected abstract EntitiesSettings CreateSettings();

        /// <summary>
        /// Построить опции контекста базы данных.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public abstract void BuildDbContextOptions(DbContextOptionsBuilder builder);

        #endregion Protected methods

        #region Private methods

        private DbContextOptions<MapperDbContext> CreateDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder<MapperDbContext>();

            BuildDbContextOptions(builder);

            return builder.Options;
        }

        private void Initialize(string connectionString, EntitiesSettings settings, Environment environment)
        {
            Environment = environment ?? new();
            Settings = settings ?? CreateSettings();
            ConnectionString = connectionString ?? CreateConnectionString();
            Options = CreateDbContextOptions();
        }

        #endregion Private methods
    }
}
