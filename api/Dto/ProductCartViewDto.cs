using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace api.Dto
{
    public class ProductCartViewDto
    {
        public int ProductId {get;set;}
        public string Name {get;set;}
        public int ProductPrices {get;set;}
        public int HighestBid {get;set;}
        public int MyBid {get;set;}
        public DateTime BiddingEndDate {get;set;}
    }
}