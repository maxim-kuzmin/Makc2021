//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyTreeLink;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTreeLink
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyTreeLink". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleDummyTreeLinkEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyTreeLinkEntityEFObject CreateEntityEFObject(
            this SampleDummyTreeLinkEntityObject source
            )
        {
            var result = new SampleDummyTreeLinkEntityEFObject();

            new SampleDummyTreeLinkEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyTreeLinkEntityObject CreateEntityObject(
            this SampleDummyTreeLinkEntityEFObject source
            )
        {
            var loader = new SampleDummyTreeLinkEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
