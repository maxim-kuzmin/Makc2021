//Author Maxim Kuzmin//makc//

using Makc2021.Layer1;
using Microsoft.EntityFrameworkCore;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Db
{
    /// <summary>
    /// Источник "Sample". ORM "Entity Framework". Фабрика базы данных.
    /// </summary>
    public abstract class SampleEFDbFactory
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

        /// <summary>
        /// Опции.
        /// </summary>
        public DbContextOptions<SampleEFDbContext> Options { get; private set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public SampleSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public SampleEFDbFactory()
        {
            Initialize(null, null, null);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        /// <param name="settings">Настройки.</param>
        /// <param name="environment">Окружение.</param>
        public SampleEFDbFactory(
            string connectionString,
            SampleSettings settings,
            Environment environment
            )
        {
            Initialize(connectionString, settings, environment);
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать контекст базы данных.
        /// </summary>
        /// <returns>Контекст базы данных.</returns>
        public abstract SampleEFDbContext CreateDbContext();

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
        protected abstract SampleSettings CreateSettings();

        /// <summary>
        /// Построить опции контекста базы данных.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        public abstract void BuildDbContextOptions(DbContextOptionsBuilder builder);

        #endregion Protected methods

        #region Private methods

        private DbContextOptions<SampleEFDbContext> CreateDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder<SampleEFDbContext>();

            BuildDbContextOptions(builder);

            return builder.Options;
        }

        private void Initialize(
            string connectionString,
            SampleSettings settings,
            Environment environment
            )
        {
            Environment = environment ?? new Environment
            {
                BasePath = System.AppContext.BaseDirectory
            };

            Settings = settings ?? CreateSettings();
            ConnectionString = connectionString ?? CreateConnectionString();
            Options = CreateDbContextOptions();
        }

        #endregion Private methods
    }
}
