//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.RoleClaim;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.RoleClaim
{
    /// <summary>
    /// Источник "Sample". Сущность "RoleClaim". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleRoleClaimEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleRoleClaimEntityEFObject CreateEntityEFObject(
            this SampleRoleClaimEntityObject source
            )
        {
            var result = new SampleRoleClaimEntityEFObject();

            new SampleRoleClaimEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleRoleClaimEntityObject CreateEntityObject(
            this SampleRoleClaimEntityEFObject source
            )
        {
            var loader = new SampleRoleClaimEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
