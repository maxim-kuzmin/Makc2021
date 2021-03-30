// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.List;
using Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.List.Queries.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Makc2021.Layer6.Apps.WebAPI.Controllers.Pages.DummyMain.List
{
    /// <summary>
    /// Контроллер страницы сущностей "DummyMain".
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/pages/dummy-main/list")]
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
        /// <param name="pageNumber">Номер страницы.</param>
        /// <param name="pageSize">Размер страницы.</param>
        /// <returns>Задача на получение результата.</returns>
        [HttpGet, Route("{pageNumber}")]
        public async Task<IActionResult> Get(int pageNumber, int pageSize)
        {
            DummyMainListPageGetQueryInput input = new();

            input.List.PageNumber = pageNumber;
            input.List.PageSize = pageSize;

            var result = await AppService.Get(input).ConfigureAwaitWithCultureSaving(false);

            return Ok(result);
        }

        #endregion Public methods
    }
}
