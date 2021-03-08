//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyTree;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyTree
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyTree". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleDummyTreeEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyTreeEntityEFObject CreateEntityEFObject(
            this SampleDummyTreeEntityObject source
            )
        {
            var result = new SampleDummyTreeEntityEFObject();

            new SampleDummyTreeEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyTreeEntityObject CreateEntityObject(
            this SampleDummyTreeEntityEFObject source
            )
        {
            var loader = new SampleDummyTreeEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
