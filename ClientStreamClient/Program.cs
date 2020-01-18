using Greet;
using Grpc.Core;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientStreamClient
{
    class Program
    {
        const int _port = 50054;

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

                    if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
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

                //var request = new GreetingManyTimesRequest() { Greeting = greeting };
                //var response = client.GreetManyTimes(request);

                //Console.WriteLine($"Client sending {request.Greeting.FirstName}, {request.Greeting.LastName}");
                ////Console.WriteLine($"Result: {response.Result}");

                //while (await response.ResponseStream.MoveNext())
                //{
                //    Console.WriteLine($"Result : {response.ResponseStream.Current.Result}");
                //    await Task.Delay(200);
                //}

                var request = new LongGreetingRequest() { Greeting = greeting };
                var stream = client.LongGreet();

                foreach (int i in Enumerable.Range(1,10))
                {
                    await stream.RequestStream.WriteAsync(request);
                }

                await stream.RequestStream.CompleteAsync();

                var response = await stream.ResponseAsync;
                Console.WriteLine($"Response is: {Environment.NewLine} {response.Result}");

                channel.ShutdownAsync().Wait();
                Console.ReadKey();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }
    }
}
