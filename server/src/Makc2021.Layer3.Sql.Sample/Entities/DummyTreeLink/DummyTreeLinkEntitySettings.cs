// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Db;
using Makc2021.Layer3.Sql.Sample.Entities.DummyTree;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.DummyTreeLink
{
    /// <summary>
    /// Настройки сущности "DummyTreeLink".
    /// </summary>
    public class DummyTreeLinkEntitySettings : EntitySettings
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
        /// <param name="dbDefaults">Значения по умолчанию в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyTreeLinkEntitySettings(
            DummyTreeEntitySettings settingOfDummyTreeEntity,
            DbDefaults dbDefaults,
            string dbTable,
            string dbSchema = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {
            DbColumnForId = dbDefaults.DbColumnForId;
            DbColumnForDummyTreeEntityParentId = dbDefaults.DbColumnForParentId;

            DbForeignKeyToDummyTreeEntity = CreateDbForeignKeyName(DbTable, settingOfDummyTreeEntity.DbTable);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
