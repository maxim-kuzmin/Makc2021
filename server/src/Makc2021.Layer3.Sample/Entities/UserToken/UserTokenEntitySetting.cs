// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Db;
using Makc2021.Layer3.Sample.Entities.User;
using Makc2021.Layer3.Sample.Entity;

namespace Makc2021.Layer3.Sample.Entities.UserToken
{
    /// <summary>
    /// Настройка сущности "UserToken".
    /// </summary>
    public class UserTokenEntitySetting : EntitySetting
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "LoginProvider".
        /// </summary>
        public string DbColumnForLoginProvider { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Name".
        /// </summary>
        public string DbColumnForName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string DbColumnForUserEntityId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Value".
        /// </summary>
        public string DbColumnForValue { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUserEntity { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingOfUserEntity">Настройка сущности "User".</param>
        /// <param name="dbDefaults">Значения по умолчанию в базе данных.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public UserTokenEntitySetting(
            UserEntitySetting settingOfUserEntity,
            DbDefaults dbDefaults,
            string dbTable,
            string dbSchema = null
            )
            : base(dbDefaults, dbTable, dbSchema)
        {
            DbColumnForName = dbDefaults.DbColumnForName;

            DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, settingOfUserEntity.DbTable);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
