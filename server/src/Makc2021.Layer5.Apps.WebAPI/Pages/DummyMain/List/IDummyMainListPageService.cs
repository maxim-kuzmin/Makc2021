// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer1.Query;
using Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.List.Queries.Get;

namespace Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.List
{
    /// <summary>
    /// Интерфейс сервиса страницы сущностей "DummyMain".
    /// </summary>
    public interface IDummyMainListPageService
    {
        #region Methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="input">Входные данные.</param>
        /// <returns>Задача на выполнение запроса с выходными данными.</returns>
        Task<QueryResultWithOutput<DummyMainListPageGetQueryOutput>> Get(DummyMainListPageGetQueryInput input);

        #endregion Methods
    }
}
