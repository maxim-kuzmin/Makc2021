// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Query.Handlers;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.List.Get
{
    /// <summary>
    /// Интерфейс обработчика запроса на получение списка в домене.
    /// </summary>
    public interface IListGetQueryDomainHandler : IQueryWithInputAndOutputHandler<ListGetQueryDomainInput, ListGetQueryDomainOutput>
    {
    }
}
