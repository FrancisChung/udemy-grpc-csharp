using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace Server
{
    class Program
    {
        private const int Port = 50051;
        static void Main(string[] args)
        {
            Grpc.Core.Server server = null;

            try
            {
                var cert = File.ReadAllText($"SSL/server.crt");
                var key = File.ReadAllText($"SSL/server.key");
                var caCert = File.ReadAllText($"SSL/ca.crt");
                var keyPair = new KeyCertificatePair(cert, key);
                var credentials = new SslServerCredentials(new List<KeyCertificatePair>() {keyPair}, caCert, true);

                server = new Grpc.Core.Server()
                {
                    Services = { GreetingService.BindService(new GreetingServiceImpl()) },
                    Ports = { new ServerPort("127.0.0.1", Port, credentials) }
                };
                server.Start();
                Console.WriteLine(($"The Server is listening on port : {Port}"));
                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine($"The server failed to start: {e.Message}");
                throw;
            }
            finally
            {
                server?.ShutdownAsync().Wait();

                //if (server != null)
                //    server.ShutdownAsync().Wait();
            }

        }
    }
}