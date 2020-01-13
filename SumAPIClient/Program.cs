using System;
using Grpc.Core;
using SumAPI;
using System.Threading;
using Tasks = System.Threading.Tasks;
using System.IO;

namespace SumAPIClient
{
    class Program
    {
        const int _port = 50052;

        static void Main(string[] args)
        {
            try
            {
                Thread.Sleep(1000);

                Channel channel = new Channel($"localhost:{_port}", ChannelCredentials.Insecure);
                channel.ConnectAsync().ContinueWith((task) =>
                {
                    //var taskResult = (task.Status == Tasks.TaskStatus.RanToCompletion ?
                    //                                "Client Ran Successfully" :
                    //                                $"TaskStatus : {task.ToString()}");
                    //Console.ReadKey();
                    //Console.WriteLine(taskResult);

                    if (task.Status == Tasks.TaskStatus.RanToCompletion)
                        Console.WriteLine("The Client connected successfully");
                    else
                        Console.WriteLine($"Client Task Status: {task.ToString()}");
                });

                var client = new SumService.SumServiceClient(channel);

                var request = new SumRequest()
                {
                    Number1 = 10,
                    Number2 = 3
                };

                Console.WriteLine($"Client sending {request.Number1}, {request.Number2}");


                var response = client.Sum(request);

                Console.WriteLine($"Result: {response.Result}");

                Console.ReadKey();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }
    }
}
