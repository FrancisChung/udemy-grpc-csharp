using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Greet;
using static Greet.GreetingService;
using Grpc.Core;
using System.Linq;

namespace ServerStreamServer
{
    class GreetingServiceImpl : GreetingServiceBase
    {
        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {
            string result = $"Hello {request.Greeting.FirstName} {request.Greeting.LastName}";
            return Task.FromResult(new GreetingResponse() { Result = result });
            //return base.Greet(request, context);
        }

        public override async Task GreetManyTimes(GreetingManyTimesRequest request, IServerStreamWriter<GreetingManyTimesResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine($"The Server received the request : {request.ToString()}");

            string result = $"Hello  {request.Greeting.FirstName} {request.Greeting.LastName}";

            foreach (int i in Enumerable.Range(1,10))
            {
                await responseStream.WriteAsync(new GreetingManyTimesResponse() { Result = result });
            }
        }
    }
}
