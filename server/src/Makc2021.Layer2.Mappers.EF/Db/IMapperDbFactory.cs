// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer2.Mappers.EF.Db
{
    /// <summary>
    /// Интерфейс фабрики базы данных сопоставителя.
    /// </summary>
    /// <typeparam name="TEntitiesSettings">Тип настроек сущностей.</typeparam>
    public interface IMapperDbFactory<TEntitiesSettings>
    {
        #region Properties

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        TEntitiesSettings EntitiesSettings { get; }

        #endregion Properties
    }
}
