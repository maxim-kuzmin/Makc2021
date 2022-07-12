// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Db;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.DummyOneToMany
{
    /// <summary>
    /// Настройки сущности "DummyOneToMany".
    /// </summary>
    public class DummyOneToManyEntitySettings : EntitySettings
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
        /// <param name="dbDefaults">Значения по умолчанию в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public DummyOneToManyEntitySettings(
            DbDefaults dbDefaults,
            string dbTable,
            string dbSchema = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {
            DbColumnForId = dbDefaults.DbColumnForId;
            DbColumnForName = dbDefaults.DbColumnForName;

            DbMaxLengthForName = 256;

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

            DbUniqueIndexForName = CreateDbUniqueIndexName(DbTable, DbColumnForName);
        }

        #endregion Constructors
    }
}
