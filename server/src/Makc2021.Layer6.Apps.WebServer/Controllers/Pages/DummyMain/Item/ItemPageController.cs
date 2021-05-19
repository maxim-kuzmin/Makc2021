// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer5.Apps.Server.Pages.DummyMain.Item;
using Makc2021.Layer5.Apps.Server.Pages.DummyMain.Item.Queries.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Makc2021.Layer6.Apps.WebServer.Controllers.Pages.DummyMain.Item
{
    /// <summary>
    /// Контроллер страницы сущности "DummyMain".
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/pages/dummy-main/item/{queryCode}")]
    public class ItemPageController : ControllerBase
    {
        #region Properties

        private IItemPageService AppService { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appService">Сервис.</param>
        public ItemPageController(IItemPageService appService)
        {
            AppService = appService;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить.
        /// </summary>
        /// <param name="queryCode">Код запроса.</param>
        /// <param name="entityId">Идентификатор сущности.</param>
        /// <returns>Задача на получение результата.</returns>
        [HttpGet, Route("{entityId}")]
        public async Task<IActionResult> Get(string queryCode, int entityId)
        {
            ItemPageGetQueryInput input = new();

            input.Item.EntityId = entityId;

            var queryResult = await AppService.Get(input, queryCode).ConfigureAwaitWithCultureSaving(false);

            return Ok(queryResult);
        }

        #endregion Public methods
    }
}
