//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyTree;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTree
{
    /// <summary>
    /// Сущность "DummyTree". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class DummyTreeEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyTreeEntityEFObject CreateEntityEFObject(
            this DummyTreeEntityObject source
            )
        {
            var result = new DummyTreeEntityEFObject();

            new DummyTreeEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyTreeEntityObject CreateEntityObject(
            this DummyTreeEntityEFObject source
            )
        {
            var loader = new DummyTreeEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
