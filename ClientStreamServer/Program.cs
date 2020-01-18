using Greet;
using Grpc.Core;
using System;
using System.IO;

namespace ClientStreamServer
{
    class Program
    {
        const int _port = 50054;
        static void Main(string[] args)
        {
            Grpc.Core.Server server = null;
            try
            {
                server = new Grpc.Core.Server()
                {
                    Services = { GreetingService.BindService(new GreetingServiceImpl()) },
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
            finally
            {
                server?.ShutdownAsync().Wait();
            }
        }
    }
}
