//Author Maxim Kuzmin//makc//

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Схема ORM.
    /// </summary>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class MapperSchema<TEntityObject> : Layer2.Mappers.EF.MapperSchema<TEntityObject, EntitiesSettings>
        where TEntityObject : class
    {
        #region Constructors

        /// <inheritdoc/>
        public MapperSchema(EntitiesSettings entitiesSettings)
            : base(entitiesSettings)
        {
        }

        #endregion Constructors
    }
}
