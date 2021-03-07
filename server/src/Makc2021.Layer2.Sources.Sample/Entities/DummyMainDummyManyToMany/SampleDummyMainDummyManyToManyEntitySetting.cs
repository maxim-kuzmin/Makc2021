//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyMain;
using Makc2021.Layer2.Sources.Sample.Entities.DummyManyToMany;

namespace Makc2021.Layer2.Sources.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyMainDummyManyToMany". Настройка.
    /// </summary>
    public class SampleDummyMainDummyManyToManyEntitySetting : SampleSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "DummyMain".
        /// </summary>
        public string DbColumnNameForObjectDummyMainId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "DummyManyToMany".
        /// </summary>
        public string DbColumnNameForObjectDummyManyToManyId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyMain".
        /// </summary>
        public string DbForeignKeyToDummyMain { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyManyToMany".
        /// </summary>
        public string DbForeignKeyToDummyManyToMany { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "ObjectDummyManyToManyId".
        /// </summary>
        public string DbIndexForObjectDummyManyToManyId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingOfDummyMainEntity">Настройка сущности "DummyMain".</param>
        /// <param name="settingOfDummyManyToManyEntity">Настройка сущности "DummyManyToMany".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public SampleDummyMainDummyManyToManyEntitySetting(
            SampleDummyMainEntitySetting settingOfDummyMainEntity,
            SampleDummyManyToManyEntitySetting settingOfDummyManyToManyEntity,
            SampleDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForObjectDummyMainId = CreateNameOfColumn(
                settingOfDummyMainEntity.DbTable,
                settingOfDummyMainEntity.DbColumnNameForId
                );

            DbColumnNameForObjectDummyManyToManyId = CreateNameOfColumn(
                settingOfDummyManyToManyEntity.DbTable,
                settingOfDummyManyToManyEntity.DbColumnNameForId
                );

            DbForeignKeyToDummyMain = CreateNameOfForeignKey(DbTable, settingOfDummyMainEntity.DbTable);
            DbForeignKeyToDummyManyToMany = CreateNameOfForeignKey(DbTable, settingOfDummyManyToManyEntity.DbTable);

            DbIndexForObjectDummyManyToManyId = CreateNameOfIndex(DbTable, DbColumnNameForObjectDummyManyToManyId);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
