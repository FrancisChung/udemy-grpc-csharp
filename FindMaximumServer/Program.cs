using System;
using System.Threading;
using System.IO;
using FindMaximumServer;
using Grpc.Core;
using Max;

namespace FindMaximumServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int _port = 50056;

            Grpc.Core.Server server = null;
            try
            {
                server = new Grpc.Core.Server()
                {
                    Services = { FindMaxService.BindService(new FindMaxServiceImpl())},
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