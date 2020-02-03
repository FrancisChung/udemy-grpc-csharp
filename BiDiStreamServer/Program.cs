using System;
using System.Threading;
using System.IO;
using Greet;
using Grpc.Core;

namespace BiDiStreamServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int _port = 50055;

            Grpc.Core.Server server = null;
            try
            {
                server = new Grpc.Core.Server()
                {
                    Services = { GreetingService.BindService(new GreetingServiceImpl()) },
                    Ports = { new ServerPort("localhost", _port, ServerCredentials.Insecure) }
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
