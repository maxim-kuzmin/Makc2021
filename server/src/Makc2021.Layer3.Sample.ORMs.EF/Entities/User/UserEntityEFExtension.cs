//Author Maxim Kuzmin//makc//

using Makc2021.Layer3.Sample.Entities.User;

namespace Makc2021.Layer3.Sample.ORMs.EF.Entities.User
{
    /// <summary>
    /// Сущность "User". ORM "Entity Framework". Расширение.
    /// </summary>
    public static class UserEntityEFExtension
    {
        #region Public methods

        /// <summary>
        /// Создать объект Entity Framework, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <returns>Объект Entity Framework, где хранятся данные сущности "DummyMain".</returns>
        public static UserEntityEFObject CreateEntityEFObject(
            this UserEntityObject source
            )
        {
            var result = new UserEntityEFObject();

            new UserEntityLoader(result).LoadDataFrom(source);
            
            return result;
        }

        /// <summary>
        /// Создать объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        /// <returns>Объект сущности "DummyMain".</returns>
        public static UserEntityObject CreateEntityObject(
            this UserEntityEFObject source
            )
        {
            var loader = new UserEntityLoader();

            loader.LoadDataFrom(source);
            
            return loader.EntityObject;
        }

        #endregion Public methods
    }
}
