//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.UserRole;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.UserRole
{
    /// <summary>
    /// Источник "Sample". Сущность "UserRole". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleUserRoleEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserRoleEntityEFObject CreateEntityEFObject(
            this SampleUserRoleEntityObject source
            )
        {
            var result = new SampleUserRoleEntityEFObject();

            new SampleUserRoleEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleUserRoleEntityObject CreateEntityObject(
            this SampleUserRoleEntityEFObject source
            )
        {
            var loader = new SampleUserRoleEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
