using System;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace DeadlineClient
{
    class Program
    {
        private const string target = "127.0.0.1:50059";
        static async Task Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure);
            await channel.ConnectAsync().ContinueWith((task) =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                        Console.WriteLine($"The client connected successfully");
                }
                );
            var client = new GreetingService.GreetingServiceClient(channel);

            try
            {
                var response = client.GreetDeadline(new GreetDeadlineRequest() {Name = "John"},
                    deadline: DateTime.UtcNow.AddMilliseconds(500));
                Console.WriteLine(response.Result);
            }
            catch (RpcException e) when (e.StatusCode == StatusCode.DeadlineExceeded)
            {
                Console.WriteLine($"Error: {e.Status.Detail}");
            }

            channel.ShutdownAsync().Wait();
            Console.ReadKey();

        }
    }
}
