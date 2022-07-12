// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer5.Sql.Server.Pages.DummyMain.List;
using Makc2021.Layer5.Sql.Server.Pages.DummyMain.List.Queries.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Makc2021.Layer6.Sql.WebHttpServer.Controllers.Pages.DummyMain.List
{
    /// <summary>
    /// Контроллер страницы сущностей "DummyMain".
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/pages/dummy-main/list/{queryCode}")]
    public class DummyMainListPageController : ControllerBase
    {
        #region Properties

        private IDummyMainListPageService Service { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="service">Сервис.</param>
        public DummyMainListPageController(IDummyMainListPageService service)
        {
            Service = service;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="queryCode">Код запроса.</param>
        /// <param name="pageNumber">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <param name="sortDirection">Направление сортировки.</param>
        /// <param name="sortField">Поле сортировки.</param>
        /// <param name="entityName">Имя сущности.</param>
        /// <returns>Задача на получение результата.</returns>
        [HttpGet]
        public async Task<IActionResult> Get(
            string queryCode,
            int pageNumber,
            int pageSize,
            string sortDirection,
            string sortField,
            string entityName
            )
        {
            DummyMainListPageGetQueryInput input = new();

            input.List.PageNumber = pageNumber;
            input.List.PageSize = pageSize;
            input.List.SortDirection = sortDirection;
            input.List.SortField = sortField;
            input.List.EntityName = entityName;

            var queryResult = await Service.Get(input, queryCode).ConfigureAwaitWithCultureSaving(false);

            return Ok(queryResult);
        }

        #endregion Public methods
    }
}
