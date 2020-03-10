using System;
using Grpc.Core;
using static Greet.GreetingService;

namespace DeadlineServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int _port = 50059;

            Server server = new Server()
            {
                Services = { Greet.GreetingService.BindService(new GreetingServiceImpl()) },
                Ports = { new ServerPort("localhost", _port, ServerCredentials.Insecure)}
            };

            server.Start();
            Console.WriteLine($"Server started at Port {_port}");

            Console.ReadKey();
        }
    }
}
