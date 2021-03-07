﻿//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.Sources.Sample.Entities.DummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyManyToMany". Настройка.
    /// </summary>
    public class SampleDummyManyToManyEntitySetting : SampleSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Name".
        /// </summary>
        public string DbColumnNameForName { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "Name".
        /// </summary>
        public int DbMaxLengthForName { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Наименование уникального индекса в базе данных для поля "Name".
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
        public SampleDummyManyToManyEntitySetting(
            SampleDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForId = defaults.ColumnNameForId;
            DbColumnNameForName = defaults.ColumnNameForName;

            DbMaxLengthForName = 256;

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);

            DbUniqueIndexForName = CreateNameOfUniqueIndex(DbTable, DbColumnNameForName);
        }

        #endregion Constructors
    }
}
