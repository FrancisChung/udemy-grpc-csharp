using System;
using Grpc.Core;

namespace SqrtServer
{
    class Program
    {
        const int _port = 50058;
        static void Main(string[] args)
        {
            
            Server server = new Server(){
                Services = { Sqrt.SqrtService.BindService(new SqrtServiceImpl()) },
                Ports = { new ServerPort("localhost", _port, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine($"Sqrt Service started at port {_port}");
            Console.ReadKey();
        }
    }
}
