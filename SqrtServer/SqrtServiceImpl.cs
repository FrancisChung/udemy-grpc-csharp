using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Sqrt;
using static Sqrt.SqrtService;

namespace SqrtServer
{
    class SqrtServiceImpl :SqrtServiceBase   
    {
        public override async  Task<SqrtResponse> Sqrt(SqrtRequest request, ServerCallContext context)
        {
            var num = request.Number;

            if (num >= 0)
                return new SqrtResponse() { SquareRoot = Math.Sqrt(num) };
            else
                throw new RpcException(new Status(StatusCode.InvalidArgument, $"number : {num}"));
        }
    }
}
