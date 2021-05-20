using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Makc2021.Layer1.Completion;
using Makc2021.Layer5.Apps.Server.Pages.DummyMain.List;
using Makc2021.Layer5.Apps.Server.Pages.DummyMain.List.Queries.Get;
using Makc2021.Layer5.Apps.GrpcServer.Protos.Pages.DummyMain.List;

namespace Makc2021.Layer6.Apps.WebGrpcServer.Services.Pages.DummyMain.List
{
    public class DummyMainListPageService : DummyMainListPage.DummyMainListPageBase
    {
        #region Properties

        private IDummyMainListPageService AppService { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// �����������.
        /// </summary>
        /// <param name="appService">������.</param>
        public DummyMainListPageService(IDummyMainListPageService appService)
        {
            AppService = appService;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// ��������.
        /// </summary>
        /// <param name="request">������.</param>
        /// <param name="context">��������.</param>
        /// <returns>������ �� ��������� ������.</returns>
        public async override Task<DummyMainListPageGetReply> Get(
            DummyMainListPageGetRequest request,
            ServerCallContext context
            )
        {
            DummyMainListPageGetQueryInput input = new();

            input.List.PageNumber = request.List.PageNumber;
            input.List.PageSize = request.List.PageSize;
            input.List.SortDirection = request.List.SortDirection;
            input.List.SortField = request.List.SortField;
            input.List.EntityName = request.List.EntityName;

            var queryResult = await AppService.Get(input, request.QueryCode).ConfigureAwaitWithCultureSaving(false);

            var result = new DummyMainListPageGetReply
            {
                IsOk = queryResult.IsOk,
                Output = new()
                {
                    List = new()
                    {
                        TotalCount = queryResult.Output.List.TotalCount
                    }
                },
                QueryCode = queryResult.QueryCode
            };

            result.ErrorMessages.AddRange(queryResult.ErrorMessages);            
            result.WarningMessages.AddRange(queryResult.WarningMessages);
            result.SuccessMessages.AddRange(queryResult.SuccessMessages);

            result.Output.List.Items.AddRange(
                queryResult.Output.List.Items.Select(x =>
                    new DummyMainDomainItemGetQueryOutput
                    {
                        ObjectOfDummyMainEntity = new()
                        {
                            Id = x.ObjectOfDummyMainEntity.Id,
                            Name = x.ObjectOfDummyMainEntity.Name
                        }
                    })
                );

            return result;
        }

        #endregion Public methods
    }
}
