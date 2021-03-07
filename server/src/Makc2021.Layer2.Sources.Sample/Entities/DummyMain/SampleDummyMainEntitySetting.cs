﻿//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyOneToMany;

namespace Makc2021.Layer2.Sources.Sample.Entities.DummyMain
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyMain". Настройка.
    /// </summary>
    public class SampleDummyMainEntitySetting : SampleSetting
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
        /// Имя колонки в базе данных для поля идентификатора сущности "DummyOneToMany".
        /// </summary>
        public string DbColumnNameForObjectDummyOneToManyId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropBoolean".
        /// </summary>
        public string DbColumnNameForPropBoolean { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropBooleanNullable".
        /// </summary>
        public string DbColumnNameForPropBooleanNullable { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropDate".
        /// </summary>
        public string DbColumnNameForPropDate { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropDateNullable".
        /// </summary>
        public string DbColumnNameForPropDateNullable { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropDateTimeOffset".
        /// </summary>
        public string DbColumnNameForPropDateTimeOffset { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropDateTimeOffsetNullable".
        /// </summary>
        public string DbColumnNameForPropDateTimeOffsetNullable { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropDecimal".
        /// </summary>
        public string DbColumnNameForPropDecimal { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropDecimalNullable".
        /// </summary>
        public string DbColumnNameForPropDecimalNullable { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropInt32".
        /// </summary>
        public string DbColumnNameForPropInt32 { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropInt32Nullable".
        /// </summary>
        public string DbColumnNameForPropInt32Nullable { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropInt64".
        /// </summary>
        public string DbColumnNameForPropInt64 { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropInt64Nullable".
        /// </summary>
        public string DbColumnNameForPropInt64Nullable { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropString".
        /// </summary>
        public string DbColumnNameForPropString { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "PropStringNullable".
        /// </summary>
        public string DbColumnNameForPropStringNullable { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyOneToMany".
        /// </summary>
        public string DbForeignKeyToDummyOneToMany { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "ObjectDummyOneToManyId".
        /// </summary>
        public string DbIndexForObjectDummyOneToManyId { get; set; }

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
        /// <param name="settingOfDummyOneToManyEntity">Настройка сущности "DummyOneToMany".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public SampleDummyMainEntitySetting(
            SampleDummyOneToManyEntitySetting settingOfDummyOneToManyEntity,
            SampleDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForId = defaults.ColumnNameForId;
            DbColumnNameForName = defaults.ColumnNameForName;

            DbColumnNameForObjectDummyOneToManyId = CreateNameOfColumn(
                settingOfDummyOneToManyEntity.DbTable,
                settingOfDummyOneToManyEntity.DbColumnNameForId
                );

            DbForeignKeyToDummyOneToMany = CreateNameOfForeignKey(DbTable, settingOfDummyOneToManyEntity.DbTable);

            DbIndexForObjectDummyOneToManyId = CreateNameOfIndex(DbTable, DbColumnNameForObjectDummyOneToManyId);

            DbMaxLengthForName = 256;

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);

            DbUniqueIndexForName = CreateNameOfUniqueIndex(DbTable, DbColumnNameForName);
        }

        #endregion Constructors
    }
}
