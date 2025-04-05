using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using static Greet.GreetingService;

namespace ReflectionServer
{
    public class GreetingServiceImpl : GreetingServiceBase
    {
        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {
            string result = $"Hello {request.Greeting.FirstName} {request.Greeting.LastName}";
            return Task.FromResult(new GreetingResponse() { Result = result });
            //return base.Greet(request, context);
        }
    }
}
