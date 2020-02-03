using AverageAPI;
using Grpc.Core;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AvgClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var target = "localhost:50055";
            Thread.Sleep(1000);

            Channel channel = new Channel(target, ChannelCredentials.Insecure);
            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The Client connected successfully");
                else
                    Console.WriteLine($"Client Task Status: {task.ToString()}");

            });

            //var client = AverageService.AverageServiceClient();
            var client = new AverageService.AverageServiceClient(channel);

            int[] numbers = { 1, 3, 7, 9, 11 };
            var stream = client.ComputeAverage();

            foreach (int i in numbers)
            {
                var request = new AverageRequest() { Number = i };
                await stream.RequestStream.WriteAsync(request);
            }

            await stream.RequestStream.CompleteAsync();

            var response = await stream.ResponseAsync;

            Console.WriteLine($"ComputedAverage is: {Environment.NewLine} {response.Average}");

            channel.ShutdownAsync().Wait();
            Console.ReadKey();

        }
    }
}
