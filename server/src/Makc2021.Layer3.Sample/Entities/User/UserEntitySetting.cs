//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.Entities.User
{
    /// <summary>
    /// Настройка сущности "User".
    /// </summary>
    public class UserEntitySetting : EntitySetting
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "AccessFailedCount".
        /// </summary>
        public string DbColumnForAccessFailedCount { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "ConcurrencyStamp".
        /// </summary>
        public string DbColumnForConcurrencyStamp { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Email".
        /// </summary>
        public string DbColumnForEmail { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "EmailConfirmed".
        /// </summary>
        public string DbColumnForEmailConfirmed { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "FullName".
        /// </summary>
        public string DbColumnForFullName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "NormalizedEmail".
        /// </summary>
        public string DbColumnForNormalizedEmail { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "LockoutEnabled".
        /// </summary>
        public string DbColumnForLockoutEnabled { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "LockoutEnd".
        /// </summary>
        public string DbColumnForLockoutEnd { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "NormalizedUserName".
        /// </summary>
        public string DbColumnForNormalizedUserName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PasswordHash".
        /// </summary>
        public string DbColumnForPasswordHash { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PhoneNumber".
        /// </summary>
        public string DbColumnForPhoneNumber { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "PhoneNumberConfirmed".
        /// </summary>
        public string DbColumnForPhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "SecurityStamp".
        /// </summary>
        public string DbColumnForSecurityStamp { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TwoFactorEnabled".
        /// </summary>
        public string DbColumnForTwoFactorEnabled { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "UserName".
        /// </summary>
        public string DbColumnForUserName { get; set; }

        /// <summary>
        /// Индекс в базе данных для поля "NormalizedEmail".
        /// </summary>
        public string DbIndexForNormalizedEmail { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Уникальный индекс в базе данных для поля "NormalizedUserName".
        /// </summary>
        public string DbUniqueIndexForNormalizedUserName { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        /// <param name="dbColumnNameForNormalizedEmail">Колонка в базе данных для поля "NormalizedEmail".</param>
        /// <param name="dbColumnNameForNormalizedUserName">Колонка в базе данных для поля "NormalizedUserName".</param>
        public UserEntitySetting(
            Defaults defaults,
            string dbTable,
            string dbSchema = null,
            string dbColumnNameForNormalizedEmail = null,
            string dbColumnNameForNormalizedUserName = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnForId = defaults.DbColumnForId;

            DbColumnForNormalizedEmail = dbColumnNameForNormalizedEmail
                ?? nameof(UserEntityObject.NormalizedEmail);

            DbColumnForNormalizedUserName = dbColumnNameForNormalizedUserName
                ?? nameof(UserEntityObject.NormalizedUserName);

            DbIndexForNormalizedEmail = CreateNameOfIndex(
                DbTable,
                DbColumnForNormalizedEmail
                );

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);

            DbUniqueIndexForNormalizedUserName = CreateNameOfUniqueIndex(
                DbTable,
                DbColumnForNormalizedUserName
                );
        }

        #endregion Constructors
    }
}
