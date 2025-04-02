using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Max;
using static Max.FindMaxService;

namespace FindMaximumServer
{ 
    public class FindMaxServiceImpl : FindMaxService.FindMaxServiceBase
    {
        public override async Task findMaximum(IAsyncStreamReader<FindMaxRequest> requestStream, IServerStreamWriter<FindMaxResponse> responseStream, ServerCallContext context)
        {
            int currentMax = 0;
            while (await requestStream.MoveNext())
            {
                var number = requestStream.Current.Number;
                if (number > currentMax)
                {
                    currentMax = number;
                    await responseStream.WriteAsync(new FindMaxResponse() { Max = currentMax });
                }
            }
        }
    }
}
