﻿//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.Role;
using Makc2021.Layer2.Sources.Sample.Entities.User;

namespace Makc2021.Layer2.Sources.Sample.Entities.UserClaim
{
    /// <summary>
    /// Источник "Sample". Сущность "UserClaim". Настройка.
    /// </summary>
    public class SampleUserClaimEntitySetting : SampleSetting
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
        /// Имя колонки в базе данных для поля "UserId".
        /// </summary>
        public string DbColumnNameForUserId { get; set; }

        /// <summary>
        /// Первичный ключ в базе данных.
        /// </summary>
        public string DbPrimaryKey { get; set; }

        /// <summary>
        /// Внешний ключ в базе данных к сущности "User".
        /// </summary>
        public string DbForeignKeyToUser { get; set; }

        /// <summary>
        /// Наименование индекса в базе данных для поля "UserId".
        /// </summary>
        public string DbIndexForUserId { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settingOfUserEntity">Настройка сущности "User".</param>
        /// <param name="defaults">Значения по умолчанию.</param>
        /// <param name="dbTable">Таблица в базе данных.</param>
        /// <param name="dbSchema">Схема в базе данных.</param>
        /// <param name="dbColumnNameForUserId">Имя колонки в базе данных для поля "UserId".</param>
        public SampleUserClaimEntitySetting(
            SampleUserEntitySetting settingOfUserEntity,
            SampleDefaults defaults,
            string dbTable,
            string dbSchema = null,
            string dbColumnNameForUserId = null
            )
            : base(defaults, dbTable, dbSchema)
        {
            DbColumnNameForId = defaults.ColumnNameForId;
            DbColumnNameForUserId = dbColumnNameForUserId ?? nameof(SampleUserClaimEntityObject.UserId);

            DbForeignKeyToUser = CreateNameOfForeignKey(DbTable, settingOfUserEntity.DbTable);

            DbIndexForUserId = CreateNameOfIndex(DbTable, DbColumnNameForUserId);

            DbPrimaryKey = CreateNameOfPrimaryKey(DbTable);
        }

        #endregion Constructors
    }
}
