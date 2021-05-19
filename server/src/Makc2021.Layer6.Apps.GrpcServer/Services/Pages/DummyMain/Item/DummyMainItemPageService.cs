using System.Threading.Tasks;
using Grpc.Core;
using Makc2021.Layer1.Completion;
using Makc2021.Layer5.Apps.Server.Pages.DummyMain.Item;
using Makc2021.Layer5.Apps.Server.Pages.DummyMain.Item.Queries.Get;
using Makc2021.Layer6.Apps.GrpcServer.Protos.Pages.DummyMain.Item;

namespace Makc2021.Layer6.Apps.GrpcServer.Services.Pages.DummyMain.Item
{
    public class DummyMainItemPageService : DummyMainItemPage.DummyMainItemPageBase
    {
        #region Properties

        private IItemPageService AppService { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// �����������.
        /// </summary>
        /// <param name="appService">������.</param>
        public DummyMainItemPageService(IItemPageService appService)
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
        public async override Task<DummyMainItemPageGetReply> Get(
            DummyMainItemPageGetRequest request,
            ServerCallContext context
            )
        {
            ItemPageGetQueryInput input = new();

            input.Item.EntityId = request.Item.EntityId;

            var queryResult = await AppService.Get(input, request.QueryCode).ConfigureAwaitWithCultureSaving(false);

            var objectOfDummyMainEntity = queryResult.Output.Item.ObjectOfDummyMainEntity;

            return new DummyMainItemPageGetReply
            {
                IsOk = queryResult.IsOk,
                Output = new()
                {
                    Item = new()
                    {
                        ObjectOfDummyMainEntity = new()
                        {
                            Id = objectOfDummyMainEntity.Id,
                            Name = objectOfDummyMainEntity.Name
                        }
                    }
                },
                QueryCode = queryResult.QueryCode
            };
        }

        #endregion Public methods
    }
}
