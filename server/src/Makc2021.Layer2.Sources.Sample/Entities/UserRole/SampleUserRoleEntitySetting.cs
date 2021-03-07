//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.Role;
using Makc2021.Layer2.Sources.Sample.Entities.User;

namespace Makc2021.Layer2.Sources.Sample.Entities.UserRole
{
    /// <summary>
    /// Источник "Sample". Сущность "UserRole". Настройка.
    /// </summary>
    public class SampleUserRoleEntitySetting : SampleSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "Role".
        /// </summary>
        public string DbColumnNameForRoleId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string DbColumnNameForUserId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string DbForeignKeyToRole { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUser { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "RoleId".
        /// </summary>
        public string DbIndexForRoleId { get; set; }

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
        public SampleUserRoleEntitySetting(
            SampleRoleEntitySetting settingOfRoleEntity,
            SampleUserEntitySetting settingOfUserEntity,
            SampleDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForRoleId = CreateNameOfColumn(settingOfRoleEntity.DbTable, settingOfRoleEntity.DbColumnNameForId);
            DbColumnNameForUserId = CreateNameOfColumn(settingOfUserEntity.DbTable, settingOfUserEntity.DbColumnNameForId);

            DbForeignKeyToRole = CreateNameOfForeignKey(DbTable, settingOfRoleEntity.DbTable);
            DbForeignKeyToUser = CreateNameOfForeignKey(DbTable, settingOfUserEntity.DbTable);

            DbIndexForRoleId = CreateNameOfIndex(DbTable, DbColumnNameForRoleId);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
