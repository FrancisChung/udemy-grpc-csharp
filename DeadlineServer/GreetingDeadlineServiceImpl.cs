using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;
using static Greet.GreetingService;

namespace DeadlineServer
{
    public class GreetingDeadlineServiceImpl : GreetingServiceBase
    {
        public override async Task<GreetDeadlineResponse> GreetDeadline(GreetDeadlineRequest request, ServerCallContext context)
        {
            await Task.Delay(300);

            return new GreetDeadlineResponse { Result = $"Hello {request.Name} from the Server" };
        }
    }
}
