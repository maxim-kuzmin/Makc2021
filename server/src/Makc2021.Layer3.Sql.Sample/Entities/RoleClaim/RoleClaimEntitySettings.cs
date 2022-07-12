// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Db;
using Makc2021.Layer3.Sql.Sample.Entities.Role;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.RoleClaim
{
    /// <summary>
    /// Настройки сущности "RoleClaim".
    /// </summary>
    public class RoleClaimEntitySettings : EntitySettings
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "ClaimType".
        /// </summary>
        public string DbColumnForClaimType { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "ClaimValue".
        /// </summary>
        public string DbColumnForClaimValue { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "Role".
        /// </summary>
        public string DbColumnForRoleEntityId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string DbForeignKeyToRoleEntity { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "Role".
        /// </summary>
        public string DbUniqueIndexForRoleEntityId { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingOfRoleEntity">Настройка сущности "Role".</param>
        /// <param name="dbDefaults">Значения по умолчанию в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public RoleClaimEntitySettings(
            RoleEntitySettings settingOfRoleEntity,
            DbDefaults dbDefaults,
            string dbTable,
            string dbSchema = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {
            DbColumnForId = dbDefaults.DbColumnForId;

            DbColumnForRoleEntityId = CreateDbColumnName(
                settingOfRoleEntity.DbTable,
                settingOfRoleEntity.DbColumnForId
                );

            DbForeignKeyToRoleEntity = CreateDbForeignKeyName(DbTable, settingOfRoleEntity.DbTable);

            DbUniqueIndexForRoleEntityId = CreateDbUniqueIndexName(DbTable, DbColumnForRoleEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
