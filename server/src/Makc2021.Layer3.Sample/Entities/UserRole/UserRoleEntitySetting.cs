// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities.Role;
using Makc2021.Layer3.Sample.Entities.User;

namespace Makc2021.Layer3.Sample.Entities.UserRole
{
    /// <summary>
    /// Настройка сущности "UserRole".
    /// </summary>
    public class UserRoleEntitySetting : EntitySetting
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "Role".
        /// </summary>
        public string DbColumnForRoleEntityId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string DbColumnForUserEntityId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string DbForeignKeyToRoleEntity { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUserEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "RoleId".
        /// </summary>
        public string DbIndexForRoleEntityId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingOfRoleEntity">Настройка сущности "Role".</param>
        /// <param name="settingOfUserEntity">Настройка сущности "User".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public UserRoleEntitySetting(
            RoleEntitySetting settingOfRoleEntity,
            UserEntitySetting settingOfUserEntity,
            Defaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForRoleEntityId = CreateDbColumnName(settingOfRoleEntity.DbTable, settingOfRoleEntity.DbColumnForId);
            DbColumnForUserEntityId = CreateDbColumnName(settingOfUserEntity.DbTable, settingOfUserEntity.DbColumnForId);

            DbForeignKeyToRoleEntity = CreateDbForeignKeyName(DbTable, settingOfRoleEntity.DbTable);
            DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, settingOfUserEntity.DbTable);

            DbIndexForRoleEntityId = CreateDbIndexName(DbTable, DbColumnForRoleEntityId);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
