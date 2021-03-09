﻿//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyMain;
using Makc2021.Layer3.Sample.Entities.DummyManyToMany;

namespace Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Сущность "DummyMainDummyManyToMany". Настройка.
    /// </summary>
    public class DummyMainDummyManyToManyEntitySetting : Setting
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "DummyMain".
        /// </summary>
        public string DbColumnForDummyMainEntityId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "DummyManyToMany".
        /// </summary>
        public string DbColumnForDummyManyToManyEntityId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyMain".
        /// </summary>
        public string DbForeignKeyToDummyMainEntity { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "DummyManyToMany".
        /// </summary>
        public string DbForeignKeyToDummyManyToManyEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "DummyManyToMany".
        /// </summary>
        public string DbIndexForDummyManyToManyEntityId { get; set; }

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
        public DummyMainDummyManyToManyEntitySetting(
            DummyMainEntitySetting settingOfDummyMainEntity,
            DummyManyToManyEntitySetting settingOfDummyManyToManyEntity,
            Defaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForDummyMainEntityId = CreateNameOfColumn(
                settingOfDummyMainEntity.DbTable,
                settingOfDummyMainEntity.DbColumnForId
                );

            DbColumnForDummyManyToManyEntityId = CreateNameOfColumn(
                settingOfDummyManyToManyEntity.DbTable,
                settingOfDummyManyToManyEntity.DbColumnForId
                );

            DbForeignKeyToDummyMainEntity = CreateNameOfForeignKey(DbTable, settingOfDummyMainEntity.DbTable);
            DbForeignKeyToDummyManyToManyEntity = CreateNameOfForeignKey(DbTable, settingOfDummyManyToManyEntity.DbTable);

            DbIndexForDummyManyToManyEntityId = CreateNameOfIndex(DbTable, DbColumnForDummyManyToManyEntityId);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}