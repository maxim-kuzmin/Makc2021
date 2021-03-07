//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.DummyMain;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.DummyMain
{
    /// <summary>
    /// Источник "Sample". Сущность "DummyMain". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleDummyMainEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyMainEntityEFObject CreateEntityEFObject(this SampleDummyMainEntityObject source)
        {
            var result = new SampleDummyMainEntityEFObject();

            new SampleDummyMainEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleDummyMainEntityObject CreateEntityObject(this SampleDummyMainEntityEFObject source)
        {
            var loader = new SampleDummyMainEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
