// Copyright (c) 2021 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Threading.Tasks;
using Makc2021.Layer1.Completion;
using Makc2021.Layer5.GrpcServer.Protos.Pages.DummyMain.List;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Makc2021.Layer6.WebGrpcClient.Controllers.Pages.DummyMain.List
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

        private DummyMainListPage.DummyMainListPageClient Client { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="сlient">Клиент.</param>
        public DummyMainListPageController(DummyMainListPage.DummyMainListPageClient сlient)
        {
            Client = сlient;
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
            DummyMainListPageGetRequest request = new()
            {
                QueryCode = queryCode,
                List = new()
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    SortDirection = sortDirection,
                    SortField = sortField,
                    EntityName = entityName
                }
            };

            var reply = await Client.GetAsync(request).ResponseAsync.ConfigureAwaitWithCultureSaving(false);

            return Ok(reply);
        }

        #endregion Public methods
    }
}
