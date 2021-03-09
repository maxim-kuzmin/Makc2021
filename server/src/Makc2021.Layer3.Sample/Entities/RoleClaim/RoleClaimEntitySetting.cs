﻿//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.Role;

namespace Makc2021.Layer3.Sample.Entities.RoleClaim
{
    /// <summary>
    /// Сущность "RoleClaim". Настройка.
    /// </summary>
    public class RoleClaimEntitySetting : Setting
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
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public RoleClaimEntitySetting(
            RoleEntitySetting settingOfRoleEntity,
            Defaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.ColumnNameForId;

            DbColumnForRoleEntityId = CreateNameOfColumn(
                settingOfRoleEntity.DbTable,
                settingOfRoleEntity.DbColumnForId
                );

            DbForeignKeyToRoleEntity = CreateNameOfForeignKey(DbTable, settingOfRoleEntity.DbTable);

            DbUniqueIndexForRoleEntityId = CreateNameOfUniqueIndex(DbTable, DbColumnForRoleEntityId);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}