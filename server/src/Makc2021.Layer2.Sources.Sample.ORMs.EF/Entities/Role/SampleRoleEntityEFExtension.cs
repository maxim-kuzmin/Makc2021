//Author Maxim Kuzmin//makc//

using Makc2021.Layer2.Sources.Sample.Entities.Role;

namespace Makc2021.Layer2.Sources.Sample.ORMs.EF.Entities.Role
{
    /// <summary>
    /// Источник "Sample". Сущность "Role". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class SampleRoleEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static SampleRoleEntityEFObject CreateEntityEFObject(
            this SampleRoleEntityObject source
            )
        {
            var result = new SampleRoleEntityEFObject();

            new SampleRoleEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект, где хранятся данные сущности "DummyMain".</returns>
        public static SampleRoleEntityObject CreateEntityObject(
            this SampleRoleEntityEFObject source
            )
        {
            var loader = new SampleRoleEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.Data;
        }

        #endregion Public methods
    }
}
