using System;
using System.Threading;
using Grpc.Core;
using System.Threading.Tasks;
using PrimeAPI;
using System.IO;

namespace PrimeClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var target = "localhost:50054";
                Thread.Sleep(1000);

                var channel = new Channel(target, ChannelCredentials.Insecure);
                await channel.ConnectAsync().ContinueWith((task) =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                        Console.WriteLine($"The Client connected successfully");
                    else
                        Console.WriteLine($"Connection Status : {task.ToString()}");
                });

                var client = new PrimeService.PrimeServiceClient(channel);
                var response = client.Decompose(new PrimeRequest() { Number = 120 });

                Console.Write($"Result :");
                while (await response.ResponseStream.MoveNext())
                {
                    Console.Write($"{response.ResponseStream.Current.Decomposition},");
                    //Thread.Sleep(200);
                    await Task.Delay(200);
                }
                Console.WriteLine("");
                Console.WriteLine("Decomposition streaming finished");
                Console.ReadKey();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }
    }
}
