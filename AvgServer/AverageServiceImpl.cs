using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AverageAPI;
using Grpc.Core;
using static AverageAPI.AverageService;

namespace AvgServer
{
    class AverageServiceImpl : AverageServiceBase
    {
        public override async Task<AverageResponse> ComputeAverage(IAsyncStreamReader<AverageRequest> requestStream, ServerCallContext context)
        {
            int sum = 0;
            int count = 0;
            double avg = 0.0;
            while (await requestStream.MoveNext())
            {
                sum += requestStream.Current.Number;
                count++;
            }

            return new AverageResponse() {
                Average = (double)sum / (double)count
            };
        }
    }
}
