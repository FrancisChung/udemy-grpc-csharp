using System;
using Grpc.Core;
using PrimeAPI;

namespace PrimeServer
{
    class Program
    {
        private const int _port = 50054;
        static void Main(string[] args)
        {
            var server = new Grpc.Core.Server()
            {
                Ports = { new ServerPort("localhost", _port, ServerCredentials.Insecure) },
                Services = { PrimeService.BindService(new PrimeServiceImpl()) }
            };

            server.Start();
            Console.WriteLine($"Server Started");
            Console.ReadKey();
        }
    }
}
