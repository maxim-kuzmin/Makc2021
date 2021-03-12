// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer3.Sample.Mappers.EF.Db;

namespace Makc2021.Layer3.Sample.Mappers.EF
{
    /// <summary>
    /// Внешние зависимости ORM.
    /// </summary>
    public class MapperExternals
    {
        #region Properties

        /// <summary>
        /// Фабрика базы данных.
        /// </summary>
        public IMapperDbFactory DbFactory { get; set; }

        /// <summary>
        /// Настройки сущностей.
        /// </summary>
        public EntitiesSettings EntitiesSettings { get; set; }

        #endregion Properties
    }
}
