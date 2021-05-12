using System.Threading.Tasks;
using Grpc.Core;
using Makc2021.Layer6.Apps.GrpcAPI.Protos.Pages.DummyMain.Item;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer6.Apps.GrpcAPI.Services.Pages.DummyMain.Item
{
    public class DummyMainItemPageService : DummyMainItemPageProto.DummyMainItemPageProtoBase
    {
        private readonly ILogger _logger;

        public DummyMainItemPageService(ILogger<DummyMainItemPageService> logger)
        {
            _logger = logger;
        }

        public override Task<ItemReply> SayHello(ItemRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ItemReply
            {
                Message = "Item " + request.Name
            });
        }
    }
}
