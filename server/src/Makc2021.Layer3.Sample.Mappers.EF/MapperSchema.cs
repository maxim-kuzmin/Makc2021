// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Entities;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Схема сопоставителя.
    /// </summary>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class MapperSchema<TEntityObject> : Layer2.Mappers.EF.MapperSchema<EntitiesSettings, TEntityObject>
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
