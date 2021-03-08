//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.User;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.User
{
    /// <summary>
    /// Источник "Sample". Сущность "User". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleUserEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserEntityEFObject CreateEntityEFObject(
            this SampleUserEntityObject source
            )
        {
            var result = new SampleUserEntityEFObject();

            new SampleUserEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserEntityObject CreateEntityObject(
            this SampleUserEntityEFObject source
            )
        {
            var loader = new SampleUserEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
