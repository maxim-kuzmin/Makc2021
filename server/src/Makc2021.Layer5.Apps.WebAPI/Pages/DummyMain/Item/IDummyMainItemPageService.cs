// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer1.Query;
using Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.Item.Queries.Get;

namespace Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.Item
{
    /// <summary>
    /// Интерфейс сервиса страницы сущности "DummyMain".
    /// </summary>
    public interface IDummyMainItemPageService
    {
        #region Methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="input">Входные данные.</param>
        /// <returns>Задача на выполнение запроса с выходными данными.</returns>
        Task<QueryResultWithOutput<DummyMainItemPageGetQueryOutput>> Get(DummyMainItemPageGetQueryInput input);

        #endregion Methods
    }
}
