using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dummy;
using Grpc.Core;

namespace Client
{
    class Program
    {
        private const string Target = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            Channel channel = new Channel(Target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The Client connected successfully");
                else
                    Console.WriteLine($"Client Task Status: {task.ToString()}");
            });

            var client = new DummyService.DummyServiceClient(channel);

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
