//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.UserClaim;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserClaim
{
    /// <summary>
    /// Источник "Sample". Сущность "UserClaim". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleUserClaimEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserClaimEntityEFObject CreateEntityEFObject(
            this SampleUserClaimEntityObject source
            )
        {
            var result = new SampleUserClaimEntityEFObject();

            new SampleUserClaimEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserClaimEntityObject CreateEntityObject(
            this SampleUserClaimEntityEFObject source
            )
        {
            var loader = new SampleUserClaimEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
