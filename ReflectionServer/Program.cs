﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using Grpc.Reflection.V1Alpha;

namespace ReflectionServer
{
    class Program
    {
        private const int Port = 50051;
        static void Main(string[] args)
        {
            Grpc.Core.Server server = null;

            try
            {
                var reflectionService = new Grpc.Reflection.ReflectionServiceImpl(GreetingService.Descriptor, ServerReflection.Descriptor);
                server = new Grpc.Core.Server()
                {
                    Services =
                    {
                        GreetingService.BindService(new GreetingServiceImpl()),
                        ServerReflection.BindService(reflectionService)
                    },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
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