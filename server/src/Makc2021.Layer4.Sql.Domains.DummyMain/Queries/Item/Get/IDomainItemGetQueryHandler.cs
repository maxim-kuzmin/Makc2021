﻿// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2021.Layer1.Query.Handlers;

namespace Makc2021.Layer4.Sql.Domains.DummyMain.Queries.Item.Get
{
    /// <summary>
    /// Интерфейс обработчика запроса на получение элемента в домене.
    /// </summary>
    public interface IDomainItemGetQueryHandler :
        IQueryWithInputAndOutputHandler<DomainItemGetQueryInput, DomainItemGetQueryOutput>
    {
    }
}
