using System.Threading.Tasks;
using Grpc.Core;
using Makc2021.Layer6.Apps.GrpcServer.Protos.Pages.DummyMain.Item;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer6.Apps.GrpcServer.Services.Pages.DummyMain.Item
{
    public class DummyMainItemPageService : DummyMainItemPageProto.DummyMainItemPageProtoBase
    {
        private readonly ILogger _logger;

        public DummyMainItemPageService(ILogger<DummyMainItemPageService> logger)
        {
            _logger = logger;
        }

        public override Task<DummyMainItemPageReply> Get(DummyMainItemPageRequest request, ServerCallContext context)
        {
            return Task.FromResult(new DummyMainItemPageReply
            {
                Message = "Item.EntityId = " + request.Item.EntityId
            });
        }
    }
}
