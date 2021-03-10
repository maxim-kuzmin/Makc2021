//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2
{
    /// <summary>
    /// Значения по умолчанию.
    /// </summary>
    public class Defaults
    {
        #region Properties

        /// <summary>
        /// Колонка в базе данных для поля "Id".
        /// </summary>
        public string DbColumnForId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "Name".
        /// </summary>
        public string DbColumnForName { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "ParentId".
        /// </summary>
        public string DbColumnForParentId { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeChildCount".
        /// </summary>
        public string DbColumnForTreeChildCount { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeDescendantCount".
        /// </summary>
        public string DbColumnForTreeDescendantCount { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeLevel".
        /// </summary>
        public string DbColumnForTreeLevel { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreePath".
        /// </summary>
        public string DbColumnForTreePath { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreePosition".
        /// </summary>
        public string DbColumnForTreePosition { get; set; }

        /// <summary>
        /// Колонка в базе данных для поля "TreeSort".
        /// </summary>
        public string DbColumnForTreeSort { get; set; }

        /// <summary>
        /// Разделитель частей имени столбца.
        /// </summary>
        public string DbColumnPartsSeparator { get; set; }

        /// <summary>
        /// Префикс внешнего ключа.
        /// </summary>
        public string ForeignKeyPrefix { get; set; }

        /// <summary>
        /// Разделитель частей полного имени.
        /// </summary>
        public string FullNamePartsSeparator { get; set; }

        /// <summary>
        /// Префикс индекса в базе данных.
        /// </summary>
        public string IndexPrefix { get; set; }

        /// <summary>
        /// Разделитель частей имени.
        /// </summary>
        public string NamePartsSeparator { get; set; }

        /// <summary>
        /// Префикс первичного ключа.
        /// </summary>
        public string PrimaryKeyPrefix { get; set; }

        /// <summary>
        /// Схема.
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// Префикс уникального индекса.
        /// </summary>
        public string UniqueIndexPrefix { get; set; }

        #endregion Properties
    }
}
