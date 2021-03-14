// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Collections.Generic;
using Makc2021.Layer3.Sample.Entities.DummyMain;
using Makc2021.Layer3.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;
using SampleMapper = Makc2021.Layer3.Sample.Mappers.EF;

namespace Makc2021.Layer4.Domains.DummyMain
{
    /// <summary>
    /// Интерфейс сервиса домена.
    /// </summary>
    public interface IDomainService
    {
        #region Methods

        SampleMapper.Db.MapperDbContext CreateSampleDbContext();

        ItemGetQueryDomainOutput CreateItem(DummyMainEntityObject entity);

        void InitItemDummyManyToMany(ItemGetQueryDomainOutput item, IEnumerable<DummyManyToManyEntityMapperObject> enities);

        #endregion Methods
    }
}
