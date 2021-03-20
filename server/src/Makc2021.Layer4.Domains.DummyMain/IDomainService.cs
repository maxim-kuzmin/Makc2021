// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer4.Domains.DummyMain.Queries.Item.Get;

namespace Makc2021.Layer4.Domains.DummyMain
{
    /// <summary>
    /// Интерфейс сервиса домена.
    /// </summary>
    public interface IDomainService
    {
        #region Methods

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <param name="input">Входные данные.</param>
        /// <returns>Задача на выполнение запроса с выходными данными.</returns>
        Task<ItemGetQueryDomainOutput> GetItem(ItemGetQueryDomainInput input);

        #endregion Methods
    }
}
