using Greet;
using Grpc.Core;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BiDiStreamClient
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

            var client = new Greet.GreetingService.GreetingServiceClient(channel);

            await GreetEveryone(client);

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }

        public static async Task GreetEveryone(Greet.GreetingService.GreetingServiceClient client)
        {
            var stream = client.GreetEveryone();

            Greeting[] greetings =
            {
                new Greeting() {FirstName = "John", LastName ="Smith"},
                new Greeting() {FirstName = "Pete", LastName = "Hansen"},
                new Greeting() {FirstName = "Jane", LastName = "Doe"}
            };

            foreach (var g in greetings)
            {
                var request = new GreetEveryoneRequest() { Greeting = g };
                await stream.RequestStream.WriteAsync(request);
            }
            await stream.RequestStream.CompleteAsync();

            var responseTask = Task.Run(async () =>
            {
                while (await stream.ResponseStream.MoveNext())
                {
                    var c = stream.ResponseStream.Current;
                    Console.WriteLine($"Response is: {c.Result}");
                }
            });

            await responseTask;

            
        }
    }
}
