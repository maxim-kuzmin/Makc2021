//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyTree;

namespace Makc2021.Layer3.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Сущность "DummyTreeLink". Настройка.
    /// </summary>
    public class DummyTreeLinkEntitySetting : Setting
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора родителя сущности "DummyTreeEntity".
        /// </summary>
        public string DbColumnForDummyTreeEntityParentId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyTree".
        /// </summary>
        public string DbForeignKeyToDummyTreeEntity { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingOfDummyTreeEntity">Настройка сущности "DummyTree".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyTreeLinkEntitySetting(
            DummyTreeEntitySetting settingOfDummyTreeEntity,
            Defaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.ColumnNameForId;
            DbColumnForDummyTreeEntityParentId = defaults.ColumnNameForParentId;

            DbForeignKeyToDummyTreeEntity = CreateNameOfForeignKey(DbTable, settingOfDummyTreeEntity.DbTable);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
