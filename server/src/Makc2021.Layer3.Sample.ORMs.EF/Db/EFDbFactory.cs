//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer3.Sample.ORMs.EF.Db
{
    /// <summary>
    /// ORM "Entity Framework". Фабрика базы данных.
    /// </summary>
    public abstract class EFDbFactory : IEFDbFactory
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
        public DbContextOptions<EFDbContext> Options { get; private set; }

        /// <inheritdoc/>
        public EntitiesSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public EFDbFactory()
        {
            Initialize(null, null, null);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        /// <param name="settings">Настройки.</param>
        /// <param name="environment">Окружение.</param>
        public EFDbFactory(string connectionString, EntitiesSettings settings, Environment environment)
        {
            Initialize(connectionString, settings, environment);
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public abstract EFDbContext CreateDbContext();

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

        private DbContextOptions<EFDbContext> CreateDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder<EFDbContext>();

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
