//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.User;

namespace Makc2021.Layer2.Sources.Sample.Entities.UserLogin
{
    /// <summary>
    /// Источник "Sample". Сущность "UserLogin". Настройка.
    /// </summary>
    public class SampleUserLoginEntitySetting : SampleSetting
    {
        #region Properties

        /// <summary>
        /// Имя колонки в базе данных для поля "LoginProvider".
        /// </summary>
        public string DbColumnNameForLoginProvider { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "ProviderKey".
        /// </summary>
        public string DbColumnNameForProviderKey { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "ProviderDisplayName".
        /// </summary>
        public string DbColumnNameForProviderDisplayName { get; set; }

        /// <summary>
        /// Имя колонки в базе данных для поля "UserId".
        /// </summary>
        public string DbColumnNameForUserId { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUser { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "UserId".
        /// </summary>
        public string DbIndexForUserId { get; set; }

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
        public SampleUserLoginEntitySetting(
            SampleUserEntitySetting settingOfUserEntity,
            SampleDefaults defaults,
            string dbTable,
            string dbSchema = null,
            string dbColumnNameForUserId = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForUserId = dbColumnNameForUserId ?? nameof(SampleUserLoginEntityObject.UserId);

            DbForeignKeyToUser = CreateNameOfForeignKey(DbTable, settingOfUserEntity.DbTable);

            DbIndexForUserId = CreateNameOfIndex(DbTable, DbColumnNameForUserId);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
