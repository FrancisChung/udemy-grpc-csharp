using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FindMaximum.FindMaxService;

namespace FindMaximumServer
{ 
    internal class FindMaxServiceImpl : FindMaxServiceBase
    {
        private int? max = null;
        while (await requestStream.MoveNext())
        {
            if (!max.HasValue ||  max <requestStream.Current.Number>>)
            {
                max = requestStream.Current.Number;
                await responseStream.WriteAsync(new FindMaxResponse() { Max = max.Value });
            }
        }
    }
}
