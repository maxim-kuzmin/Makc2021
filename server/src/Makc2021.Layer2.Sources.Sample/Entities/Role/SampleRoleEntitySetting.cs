//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.Sources.Sample.Entities.Role
{
    /// <summary>
    /// Источник "Sample". Сущность "Role". Настройка.
    /// </summary>
    public class SampleRoleEntitySetting : SampleSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля "ConcurrencyStamp".
        /// </summary>
        public string DbColumnNameForConcurrencyStamp { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Name".
        /// </summary>
        public string DbColumnNameForName { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "NormalizedName".
        /// </summary>
        public string DbColumnNameForNormalizedName { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Наименование уникального индекса в базе данных для поля "NormalizedName".
        /// </summary>
        public string DbUniqueIndexForNormalizedName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public SampleRoleEntitySetting(
            SampleDefaults defaults,
            string dbTable,
            string dbSchema = null,
            string dbColumnNameForNormalizedName = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForId = defaults.ColumnNameForId;
            DbColumnNameForName = defaults.ColumnNameForName;
            DbColumnNameForNormalizedName = dbColumnNameForNormalizedName ?? nameof(SampleRoleEntityObject.NormalizedName);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);

            DbUniqueIndexForNormalizedName = CreateNameOfUniqueIndex(DbTable, DbColumnNameForNormalizedName);
        }

        #endregion Constructors
    }
}
