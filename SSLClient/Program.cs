using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dummy;
using Grpc.Core;
using Greet;
using System.Threading;

namespace Client
{
    class Program
    {
        private const string Target = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            Thread.Sleep(2000);
            Channel channel = new Channel(Target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The Client connected successfully");
                else
                    Console.WriteLine($"Client Task Status: {task.ToString()}");
            });

            //var client = new DummyService.DummyServiceClient(channel);

            var client = new GreetingService.GreetingServiceClient(channel);

            var greeting = new Greeting()
            {
                FirstName = "Francis",
                LastName = "Chung"
            };

            var request = new GreetingRequest()
            {
                Greeting = greeting
            };

            var response = client.Greet(request);
            Console.WriteLine($"Response : {response.Result}");

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}