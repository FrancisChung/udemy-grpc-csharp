using System;
using SumAPI;
using Grpc.Core;
using System.IO;

namespace SumAPIServer
{
    class Program
    {
        private const int _port = 50052;
        static void Main(string[] args)
        {
            Grpc.Core.Server server = null;
            try
            {
                server = new Grpc.Core.Server()
                {
                    Services = { SumService.BindService(new SumServiceImpl()) },
                    Ports = { new Grpc.Core.ServerPort("localhost", _port, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine(($"The Server is listening on port : {_port}"));
                Console.ReadKey();

            }
            catch (IOException e)
            {
                Console.WriteLine($"Server Connection Error: {e.Message}");
            }
            finally {
                server?.ShutdownAsync().Wait();
            }
        }
    }
}
