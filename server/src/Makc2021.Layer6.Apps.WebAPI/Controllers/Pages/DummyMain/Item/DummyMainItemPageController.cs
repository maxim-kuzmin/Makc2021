// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.Item;
using Makc2021.Layer5.Apps.WebAPI.Pages.DummyMain.Item.Queries.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Makc2021.Layer6.Apps.WebAPI.Controllers.Pages.DummyMain.Item
{
    /// <summary>
    /// Контроллер страницы сущности "DummyMain".
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/pages/dummy-main/item")]
    public class DummyMainItemPageController : ControllerBase
    {
        #region Properties

        private IDummyMainItemPageService AppService { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appService">Сервис.</param>
        public DummyMainItemPageController(IDummyMainItemPageService appService)
        {
            AppService = appService;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="entityId">Идентификатор сущности.</param>
        /// <returns>Задача на получение результата.</returns>
        [HttpGet, Route("{entityId}")]
        public async Task<IActionResult> Get(int entityId)
        {
            DummyMainItemPageGetQueryInput input = new();

            input.Item.EntityId = entityId;

            var result = await AppService.Get(input).ConfigureAwaitWithCultureSaving(false);

            return Ok(result);
        }

        #endregion Public methods
    }
}
