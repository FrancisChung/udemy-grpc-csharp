using System;
using Grpc.Core;
using Greet;
using System.Threading;
using Tasks = System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;

namespace ServerStreamClient
{
    class Program
    {
        const int _port = 50053;

        static async Task Main(string[] args)
        {
            try
            {
                Thread.Sleep(1000);

                Channel channel = new Channel($"localhost:{_port}", ChannelCredentials.Insecure);
                await channel.ConnectAsync().ContinueWith((task) =>
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

                var client = new GreetingService.GreetingServiceClient(channel);

                var greeting = new Greeting()
                {
                    FirstName = "Francis",
                    LastName = "Chung"
                };

                var request = new GreetingManyTimesRequest() { Greeting = greeting };
                var response = client.GreetManyTimes(request);

                Console.WriteLine($"Client sending {request.Greeting.FirstName}, {request.Greeting.LastName}");
                //Console.WriteLine($"Result: {response.Result}");

                while (await response.ResponseStream.MoveNext())
                {
                    Console.WriteLine($"Result : {response.ResponseStream.Current.Result}");
                    await Task.Delay(200);
                }

                Console.ReadKey();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }
    }
}
