using System.Threading.Tasks;
using Grpc.Core;
using Makc2021.Layer6.Apps.GrpcAPI.Protos.Pages.DummyMain.List;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer6.Apps.GrpcAPI.Services.Pages.DummyMain.List
{
    public class DummyMainListPageService : DummyMainListPageProto.DummyMainListPageProtoBase
    {
        private readonly ILogger _logger;

        public DummyMainListPageService(ILogger<DummyMainListPageService> logger)
        {
            _logger = logger;
        }

        public override Task<ListReply> SayHello(ListRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ListReply
            {
                Message = "List " + request.Name
            });
        }
    }
}
