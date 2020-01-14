using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using PrimeAPI;
using static PrimeAPI.PrimeService;

namespace PrimeServer
{
    class PrimeServiceImpl : PrimeServiceBase
    {
        public override async Task Decompose(PrimeRequest request, IServerStreamWriter<PrimeResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine($"Request received to decompose {request.Number}");

            int k = 2;
            int n = request.Number;
            while (n>1)
            {
                if (n % k == 0)
                {
                    await responseStream.WriteAsync(new PrimeResponse() { Decomposition = k });
                    n = n / k;
                }
                else
                    k++;
            }
            //return base.Decompose(request, responseStream, context);
        }
    }
}
