// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Db;
using Makc2021.Layer3.Sample.Entity;

namespace Makc2021.Layer3.Sample.Entities.Role
{
    /// <summary>
    /// Настройки сущности "Role".
    /// </summary>
    public class RoleEntitySettings : EntitySettings
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "ConcurrencyStamp".
        /// </summary>
        public string DbColumnForConcurrencyStamp { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Name".
        /// </summary>
        public string DbColumnForName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "NormalizedName".
        /// </summary>
        public string DbColumnForNormalizedName { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Уникальный индекс в базе данных для поля "NormalizedName".
        /// </summary>
        public string DbUniqueIndexForNormalizedName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dbDefaults">Значения по умолчанию в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public RoleEntitySettings(
            DbDefaults dbDefaults,
            string dbTable,
            string dbSchema = null,
            string dbColumnNameForNormalizedName = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {
            DbColumnForId = dbDefaults.DbColumnForId;
            DbColumnForName = dbDefaults.DbColumnForName;
            DbColumnForNormalizedName = dbColumnNameForNormalizedName ?? nameof(RoleEntityObject.NormalizedName);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

            DbUniqueIndexForNormalizedName = CreateDbUniqueIndexName(DbTable, DbColumnForNormalizedName);
        }

        #endregion Constructors
    }
}
