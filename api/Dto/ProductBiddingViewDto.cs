using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class ProductBiddingViewDto
    {
        
        public double Price {get;set;}
        public int Quantity {get;set;}

        public int UserId {get;set;}
        public string Name {get;set;}
    }
}

