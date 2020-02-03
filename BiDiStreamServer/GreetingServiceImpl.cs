using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using static Greet.GreetingService;

namespace BiDiStreamServer
{
    class GreetingServiceImpl : GreetingServiceBase
    {
        public override async Task GreetEveryone(IAsyncStreamReader<GreetEveryoneRequest> requestStream, IServerStreamWriter<GreetEveryoneResponse> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var result = $"Hello {requestStream.Current.Greeting.FirstName}," +
                    $" {requestStream.Current.Greeting.LastName}";

                Console.WriteLine($"Received: {result}");
                await responseStream.WriteAsync(new GreetEveryoneResponse() { Result = result });
            }
        }
    }
}
