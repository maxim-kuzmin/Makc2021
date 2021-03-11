//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.DummyTreeLink;

namespace Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Расширение ORM сущности "DummyTreeLink".
    /// </summary>
    public static class DummyTreeLinkEntityMapperExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static DummyTreeLinkEntityMapperObject CreateEntityEFObject(
            this DummyTreeLinkEntityObject source
            )
        {
            var result = new DummyTreeLinkEntityMapperObject();

            new DummyTreeLinkEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static DummyTreeLinkEntityObject CreateEntityObject(
            this DummyTreeLinkEntityMapperObject source
            )
        {
            var loader = new DummyTreeLinkEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
