//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer2.Sources.Sample.Entities.DummyTree
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyTree". Объект.
    /// </summary>
    public class SampleDummyTreeEntityObject
    {
        #region Properties

        /// <summary>
        /// Идентификатор узла.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор родительского узла.
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Число дочерних узлов в дереве.
        /// </summary>
        public long TreeChildCount { get; set; }

        /// <summary>
        /// Число узлов-потомков в дереве.
        /// </summary>
        public long TreeDescendantCount { get; set; }

        /// <summary>
        /// Уровень узла в дереве.
        /// </summary>
        public long TreeLevel { get; set; }

        /// <summary>
        /// Путь к узлу в дереве.
        /// </summary>
        public string TreePath { get; set; }

        /// <summary>
        /// Позиция узла в дереве.
        /// </summary>
        public int TreePosition { get; set; }

        /// <summary>
        /// Сортировка узла в дереве.
        /// </summary>
        public string TreeSort { get; set; }

        #endregion Properties
    }
}
