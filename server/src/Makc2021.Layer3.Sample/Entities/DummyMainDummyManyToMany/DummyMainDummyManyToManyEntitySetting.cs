// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.DummyMain;
using Makc2021.Layer3.Sample.Entities.DummyManyToMany;

namespace Makc2021.Layer3.Sample.Entities.DummyMainDummyManyToMany
{
    /// <summary>
    /// Настройка сущности "DummyMainDummyManyToMany".
    /// </summary>
    public class DummyMainDummyManyToManyEntitySetting : EntitySetting
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
            DbColumnForDummyMainEntityId = CreateDbColumnName(
                settingOfDummyMainEntity.DbTable,
                settingOfDummyMainEntity.DbColumnForId
                );

            DbColumnForDummyManyToManyEntityId = CreateDbColumnName(
                settingOfDummyManyToManyEntity.DbTable,
                settingOfDummyManyToManyEntity.DbColumnForId
                );

            DbForeignKeyToDummyMainEntity = CreateDbForeignKeyName(DbTable, settingOfDummyMainEntity.DbTable);
            DbForeignKeyToDummyManyToManyEntity = CreateDbForeignKeyName(DbTable, settingOfDummyManyToManyEntity.DbTable);

            DbIndexForDummyManyToManyEntityId = CreateDbIndexName(DbTable, DbColumnForDummyManyToManyEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
