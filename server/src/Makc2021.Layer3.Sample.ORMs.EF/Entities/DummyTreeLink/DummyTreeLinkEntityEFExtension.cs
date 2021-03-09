//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyTreeLink;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Сущность "DummyTreeLink". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class DummyTreeLinkEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyTreeLinkEntityEFObject CreateEntityEFObject(
            this DummyTreeLinkEntityObject source
            )
        {
            var result = new DummyTreeLinkEntityEFObject();

            new DummyTreeLinkEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyTreeLinkEntityObject CreateEntityObject(
            this DummyTreeLinkEntityEFObject source
            )
        {
            var loader = new DummyTreeLinkEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
