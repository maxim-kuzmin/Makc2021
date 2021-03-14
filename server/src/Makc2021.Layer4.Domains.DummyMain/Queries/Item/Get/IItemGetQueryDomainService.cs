// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get
{
    /// <summary>
    /// Интерфейс сервиса запроса на получение элемента в домене.
    /// </summary>
    public interface IItemGetQueryDomainService
    {
        #region Properties

        /// <summary>
        /// Функция, предназначенная для выполнения.
        /// </summary>
        Func<ItemGetQueryDomainInput, Task<ItemGetQueryDomainOutput>> FunctionToExecute { get; set; }

        #endregion Properties

        #region Methods

        Task<ItemGetQueryDomainOutput> Execute(ItemGetQueryDomainInput input);

        #endregion Methods
    }
}