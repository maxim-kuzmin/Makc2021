//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.UserToken;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserToken
{
    /// <summary>
    /// Источник "Sample". Сущность "UserToken". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleUserTokenEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserTokenEntityEFObject CreateEntityEFObject(
            this SampleUserTokenEntityObject source
            )
        {
            var result = new SampleUserTokenEntityEFObject();

            new SampleUserTokenEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserTokenEntityObject CreateEntityObject(
            this SampleUserTokenEntityEFObject source
            )
        {
            var loader = new SampleUserTokenEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
