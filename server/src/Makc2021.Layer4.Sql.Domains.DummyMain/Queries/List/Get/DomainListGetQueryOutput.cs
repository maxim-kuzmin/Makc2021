// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer2.Sql.Queries.List.Get;
using Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Queries.List.Get
{
    /// <summary>
    /// Выходные данные запроса на получение списка в домене.
    /// </summary>
    public class DomainListGetQueryOutput : ListGetQueryOutput<DomainItemGetQueryOutput>
    {
    }
}
