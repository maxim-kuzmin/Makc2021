//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.Role;

namespace Makc2021.Layer2.Sources.Sample.Entities.RoleClaim
{
    /// <summary>
    /// Источник "Sample". Сущность "RoleClaim". Настройка.
    /// </summary>
    public class SampleRoleClaimEntitySetting : SampleSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля "ClaimType".
        /// </summary>
        public string DbColumnNameForClaimType { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "ClaimValue".
        /// </summary>
        public string DbColumnNameForClaimValue { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "Id".
        /// </summary>
        public string DbColumnNameForId { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "RoleId".
        /// </summary>
        public string DbColumnNameForRoleId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "Role".
        /// </summary>
        public string DbForeignKeyToRole { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "RoleId".
        /// </summary>
        public string DbUniqueIndexForRoleId { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingOfRoleEntity">Настройка сущности "Role".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public SampleRoleClaimEntitySetting(
            SampleRoleEntitySetting settingOfRoleEntity,
            SampleDefaults defaults,
            string dbTable,
            string dbSchema = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForId = defaults.ColumnNameForId;

            DbColumnNameForRoleId = CreateNameOfColumn(
                settingOfRoleEntity.DbTable,
                settingOfRoleEntity.DbColumnNameForId
                );

            DbForeignKeyToRole = CreateNameOfForeignKey(DbTable, settingOfRoleEntity.DbTable);

            DbUniqueIndexForRoleId = CreateNameOfUniqueIndex(DbTable, DbColumnNameForRoleId);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
