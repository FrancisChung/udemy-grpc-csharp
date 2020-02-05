using System;
using Grpc.Core;
using static Sqrt.SqrtService;
using System.Threading;
using System.Threading.Tasks;

namespace SqrtClient
{
    class Program
    {
        const int _port = 50058;
        static async Task Main(string[] args)
        {
            Thread.Sleep(1000);
            Channel channel = new Channel($"localhost:{_port}", ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                    Console.WriteLine($"The client connected successfully");
            });

            var client = new SqrtServiceClient(channel);

            int number = 16;
            var request = new Sqrt.SqrtRequest() { Number = number };
            Console.WriteLine($"Sending Sqrt of {request.Number} to Server");

            try
            {
                var response = await client.SqrtAsync(request);
                Console.WriteLine($"Response Sqrt is : {response.SquareRoot}");
            }
            catch (RpcException e)
            {
                Console.WriteLine($"RPC Error : {e.Status.Detail}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
            Console.ReadKey();

        }
    }
}