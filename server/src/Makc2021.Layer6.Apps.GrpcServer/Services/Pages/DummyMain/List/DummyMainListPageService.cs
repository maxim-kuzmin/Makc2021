using System.Threading.Tasks;
using Grpc.Core;
using Makc2021.Layer6.Apps.GrpcServer.Protos.Pages.DummyMain.List;
using Microsoft.Extensions.Logging;

namespace Makc2021.Layer6.Apps.GrpcServer.Services.Pages.DummyMain.List
{
    public class DummyMainListPageService : DummyMainListPageProto.DummyMainListPageProtoBase
    {
        private readonly ILogger _logger;

        public DummyMainListPageService(ILogger<DummyMainListPageService> logger)
        {
            _logger = logger;
        }

        public override Task<DummyMainListPageReply> Get(DummyMainListPageRequest request, ServerCallContext context)
        {
            return Task.FromResult(new DummyMainListPageReply
            {
                Message = "List.PageNumber = " + request.List.PageNumber
            });
        }
    }
}
