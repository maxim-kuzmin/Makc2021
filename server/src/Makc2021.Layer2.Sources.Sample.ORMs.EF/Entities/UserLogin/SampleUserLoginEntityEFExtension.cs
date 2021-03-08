//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.UserLogin;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserLogin
{
    /// <summary>
    /// Источник "Sample". Сущность "UserLogin". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleUserLoginEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserLoginEntityEFObject CreateEntityEFObject(
            this SampleUserLoginEntityObject source
            )
        {
            var result = new SampleUserLoginEntityEFObject();

            new SampleUserLoginEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserLoginEntityObject CreateEntityObject(
            this SampleUserLoginEntityEFObject source
            )
        {
            var loader = new SampleUserLoginEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
