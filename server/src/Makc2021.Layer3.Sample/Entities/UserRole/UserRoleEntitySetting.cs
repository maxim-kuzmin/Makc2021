//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.Role;
using Makc2021.Layer3.Sample.Entities.User;

namespace Makc2021.Layer3.Sample.Entities.UserRole
{
    /// <summary>
    /// Сущность "UserRole". Настройка.
    /// </summary>
    public class UserRoleEntitySetting : Setting
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
            DbColumnForRoleEntityId = CreateNameOfColumn(settingOfRoleEntity.DbTable, settingOfRoleEntity.DbColumnForId);
            DbColumnForUserEntityId = CreateNameOfColumn(settingOfUserEntity.DbTable, settingOfUserEntity.DbColumnForId);

            DbForeignKeyToRoleEntity = CreateNameOfForeignKey(DbTable, settingOfRoleEntity.DbTable);
            DbForeignKeyToUserEntity = CreateNameOfForeignKey(DbTable, settingOfUserEntity.DbTable);

            DbIndexForRoleEntityId = CreateNameOfIndex(DbTable, DbColumnForRoleEntityId);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
