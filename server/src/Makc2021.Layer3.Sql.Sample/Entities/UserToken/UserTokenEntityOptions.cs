// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sql.Sample.Db;
using Makc2021.Layer3.Sql.Sample.Entities.User;
using Makc2021.Layer3.Sql.Sample.Entity;

namespace Makc2021.Layer3.Sql.Sample.Entities.UserToken
{
    /// <summary>
    /// Параметры сущности "UserToken".
    /// </summary>
    public class UserTokenEntityOptions : EntityOptions
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
        /// <param name="optionsOfUserEntity">Настройка сущности "User".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public UserTokenEntityOptions(
            UserEntityOptions optionsOfUserEntity,
            DbDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForName = defaults.DbColumnForName;

            DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, optionsOfUserEntity.DbTable);

            DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
        }

        #endregion Constructors
    }
}
