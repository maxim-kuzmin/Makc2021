// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2021.Layer2.Sql.Mappers.EF.Db
{
    /// <summary>
    /// Интерфейс фабрики базы данных сопоставителя.
    /// </summary>
    /// <typeparam name="TEntitiesOptions">Тип параметров сущностей.</typeparam>
    public interface IMapperDbFactory<TEntitiesOptions>
    {
        #region Properties

        /// <summary>
        /// Параметры сущностей.
        /// </summary>
        TEntitiesOptions EntitiesOptions { get; }

        #endregion Properties
    }
}
