using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Makc2021.Layer6.Apps.GrpcAPI.Protos.Pages.DummyMain.Item;
using Makc2021.Layer6.Apps.GrpcAPI.Protos.Pages.DummyMain.List;

namespace Makc2021.Layer6.Apps.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {            
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");

            await RequestItem(channel);
            await RequestList(channel);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async Task RequestItem(GrpcChannel channel)
        {
            var client = new DummyMainItemPageProto.DummyMainItemPageProtoClient(channel);
            var reply = await client.SayHelloAsync(new ItemRequest { Name = "ItemClient" });
            Console.WriteLine("Item: " + reply.Message);
        }

        private static async Task RequestList(GrpcChannel channel)
        {
            var client = new DummyMainListPageProto.DummyMainListPageProtoClient(channel);
            var reply = await client.SayHelloAsync(new ListRequest { Name = "ListClient" });
            Console.WriteLine("List: " + reply.Message);
        }
    }
}
