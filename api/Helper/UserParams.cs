using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helper
{
    public class UserParams : PaginationParams
    {
        public int TypeId {get;set;} = -1;
        public double LowPrices {get;set;} = 0;
        public double HighPrices {get;set;} = 2000000;
        public bool OrderByBiddingDuration {get;set;} = true;
    }
}