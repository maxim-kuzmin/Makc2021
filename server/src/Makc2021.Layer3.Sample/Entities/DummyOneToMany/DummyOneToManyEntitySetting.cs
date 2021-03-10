//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.Entities.DummyOneToMany
{
    /// <summary>
    /// Сущность "DummyOneToMany". Настройка.
    /// </summary>
    public class DummyOneToManyEntitySetting : EntitySetting
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Name".
        /// </summary>
        public string DbColumnForName { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "Name".
        /// </summary>
        public int DbMaxLengthForName { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Уникальный индекс в базе данных для поля "Name".
        /// </summary>
        public string DbUniqueIndexForName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyOneToManyEntitySetting(
            Defaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;
            DbColumnForName = defaults.DbColumnForName;

            DbMaxLengthForName = 256;

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);

            DbUniqueIndexForName = CreateNameOfUniqueIndex(DbTable, DbColumnForName);
        }

        #endregion Constructors
    }
}
