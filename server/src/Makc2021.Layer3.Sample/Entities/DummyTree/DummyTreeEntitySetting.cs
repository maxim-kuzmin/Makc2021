//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.Entities.DummyTree
{
    /// <summary>
    /// Настройка сущности "DummyTree".
    /// </summary>
    public class DummyTreeEntitySetting : EntitySetting
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
        /// Колонка в базе данных для поля идентификатора родителя сущности "DummyTree".
        /// </summary>
        public string DbColumnForDummyTreeEntityParentId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeChildCount".
        /// </summary>
        public string DbColumnForTreeChildCount { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeDescendantCount".
        /// </summary>
        public string DbColumnForTreeDescendantCount { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeLevel".
        /// </summary>
        public string DbColumnForTreeLevel { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreePath".
        /// </summary>
        public string DbColumnForTreePath { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreePosition".
        /// </summary>
        public string DbColumnForTreePosition { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeSort".
        /// </summary>
        public string DbColumnForTreeSort { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к родителю сущности "DummyTree".
        /// </summary>
        public string DbForeignKeyToDummyTreeEntityParent { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля "Name".
        /// </summary>
        public string DbIndexForName { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора родителя сущности "DummyTree".
        /// </summary>
        public string DbIndexForDummyTreeEntityParentId { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля "TreeSort".
        /// </summary>
        public string DbIndexForTreeSort { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "Name".
        /// </summary>
        public int DbMaxLengthForName { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "TreePath".
        /// </summary>
        public int DbMaxLengthForTreePath { get; set; }

        /// <summary>
        /// Максимальная длина в базе данных для поля "TreeSort".
        /// </summary>
        public int DbMaxLengthForTreeSort { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Индекс в базе данных для полей идентификатора родителя сущности "DummyTree" и "Name".
        /// </summary>
        public string DbUniqueIndexForDummyTreeEntityParentIdAndName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyTreeEntitySetting(
            Defaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;
            DbColumnForName = defaults.DbColumnForName;
            DbColumnForDummyTreeEntityParentId = defaults.DbColumnForParentId;
            DbColumnForTreeChildCount = defaults.DbColumnForTreeChildCount;
            DbColumnForTreeDescendantCount = defaults.DbColumnForTreeDescendantCount;
            DbColumnForTreeLevel = defaults.DbColumnForTreeLevel;
            DbColumnForTreePath = defaults.DbColumnForTreePath;
            DbColumnForTreePosition = defaults.DbColumnForTreePosition;
            DbColumnForTreeSort = defaults.DbColumnForTreeSort;

            DbForeignKeyToDummyTreeEntityParent = CreateNameOfForeignKey(DbTable, DbTable, DbColumnForDummyTreeEntityParentId);

            DbIndexForName = CreateNameOfIndex(DbTable, DbColumnForName);
            DbIndexForDummyTreeEntityParentId = CreateNameOfIndex(DbTable, DbColumnForDummyTreeEntityParentId);
            DbIndexForTreeSort = CreateNameOfIndex(DbTable, DbColumnForTreeSort);

            DbMaxLengthForName = 256;
            DbMaxLengthForTreePath = 900;
            DbMaxLengthForTreeSort = 900;

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);

            DbUniqueIndexForDummyTreeEntityParentIdAndName = CreateNameOfUniqueIndex(
                DbTable,
                DbColumnForDummyTreeEntityParentId,
                DbColumnForName
                );
        }

        #endregion Constructors
    }
}
