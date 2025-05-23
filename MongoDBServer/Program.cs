﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog;
using Greet;
using Grpc.Core;

namespace MongoDBServer
{
    class Program
    {
        private const int Port = 50051;
        static void Main(string[] args)
        {
            Grpc.Core.Server server = null;

            try
            {
                server = new Grpc.Core.Server()
                {
                    Services = { BlogService.BindService(new BlogServiceImpl()) },
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