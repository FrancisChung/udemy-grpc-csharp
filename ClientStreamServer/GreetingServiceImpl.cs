using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using static Greet.GreetingService;

namespace ClientStreamServer
{
    class GreetingServiceImpl : GreetingServiceBase
    {
        public override async Task<LongGreetingResponse> LongGreet(IAsyncStreamReader<LongGreetingRequest> requestStream, ServerCallContext context)
        {
            string result = "";
            while (await requestStream.MoveNext())
            {
                result += $"Hello {requestStream.Current.Greeting.FirstName} {requestStream.Current.Greeting.LastName} {Environment.NewLine}";
            }

            return new LongGreetingResponse() { Result = result };
            //return base.LongGreet(requestStream, context);
        }
    }
}
