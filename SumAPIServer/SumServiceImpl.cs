using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using SumAPI;
using static SumAPI.SumService;

namespace SumAPIServer
{
    class SumServiceImpl : SumServiceBase
    {
        public override Task<SumResponse> Sum(SumRequest request, ServerCallContext context)
        {
            var result = request.Number1 + request.Number2;
            var sumResponse = new SumResponse()
            {
                Result = result
            };

            return Task.FromResult(sumResponse);
            //return base.Sum(request, context);
        }
    }
}
