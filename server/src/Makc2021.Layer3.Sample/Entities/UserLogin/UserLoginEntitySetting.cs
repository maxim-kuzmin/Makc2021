//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.User;

namespace Makc2021.Layer3.Sample.Entities.UserLogin
{
    /// <summary>
    /// Сущность "UserLogin". Настройка.
    /// </summary>
    public class UserLoginEntitySetting : EntitySetting
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "LoginProvider".
        /// </summary>
        public string DbColumnForLoginProvider { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "ProviderKey".
        /// </summary>
        public string DbColumnForProviderKey { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "ProviderDisplayName".
        /// </summary>
        public string DbColumnForProviderDisplayName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string DbColumnForUserEntityId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUserEntity { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля идентификатора сущности "User".
        /// </summary>
        public string DbIndexForUserEntityId { get; set; }

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
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        public UserLoginEntitySetting(
            UserEntitySetting settingOfUserEntity,
            Defaults defaults,
            string dbTable,
            string dbSchema = null,
            string dbColumnNameForUserId = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForUserEntityId = dbColumnNameForUserId ?? nameof(UserLoginEntityObject.UserId);

            DbForeignKeyToUserEntity = CreateNameOfForeignKey(DbTable, settingOfUserEntity.DbTable);

            DbIndexForUserEntityId = CreateNameOfIndex(DbTable, DbColumnForUserEntityId);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
