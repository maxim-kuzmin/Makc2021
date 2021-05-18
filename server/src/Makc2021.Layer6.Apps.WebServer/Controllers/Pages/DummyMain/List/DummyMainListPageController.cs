// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer5.Apps.Server.Pages.DummyMain.List;
using Makc2021.Layer5.Apps.Server.Pages.DummyMain.List.Queries.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Makc2021.Layer6.Apps.WebServer.Controllers.Pages.DummyMain.List
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

        private IDummyMainListPageService AppService { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appService">Сервис.</param>
        public DummyMainListPageController(IDummyMainListPageService appService)
        {
            AppService = appService;
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

            var list = input.List;

            list.PageNumber = pageNumber;
            list.PageSize = pageSize;
            list.SortDirection = sortDirection;
            list.SortField = sortField;
            list.EntityName = entityName;

            var result = await AppService.Get(input, queryCode).ConfigureAwaitWithCultureSaving(false);

            return Ok(result);
        }

        #endregion Public methods
    }
}
