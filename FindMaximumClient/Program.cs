using Grpc.Core;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FindMaximumServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var target = "localhost:50056";
            Thread.Sleep(1000);

            Channel channel = new Channel(target, ChannelCredentials.Insecure);
            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The Client connected successfully");
                else
                    Console.WriteLine($"Client Task Status: {task.ToString()}");

            });

            var client = new Max.FindMaxService.FindMaxServiceClient(channel);
            var stream = client.findMaximum();

            var responseReaderTask = Task.Run(async () =>
            {
                while (await stream.ResponseStream.MoveNext())
                {
                    var currentMax = stream.ResponseStream.Current;
                    Console.WriteLine($"Current Max: {currentMax.Max}");
                }
            });

            int[] numbers = { 1, 5, 3, 6, 2, 20 };
            foreach (var number in numbers)
            {
                await stream.RequestStream.WriteAsync(new Max.FindMaxRequest() { Number = number });
            }

            await stream.RequestStream.CompleteAsync();
            await responseReaderTask;

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}