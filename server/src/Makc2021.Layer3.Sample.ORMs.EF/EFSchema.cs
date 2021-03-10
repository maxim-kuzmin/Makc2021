//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.ORMs.EF
{
    /// <summary>
    /// ORM "Entity Framework". Схема.
    /// </summary>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class EFSchema<TEntityObject> : Layer2.ORMs.EF.EFSchema<TEntityObject, EntitiesSettings>
        where TEntityObject : class
    {
        #region Constructors

        /// <inheritdoc/>
        public EFSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors
    }
}
