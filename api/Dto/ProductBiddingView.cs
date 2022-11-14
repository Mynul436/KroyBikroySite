using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class ProductBiddingView
    {

        public int Id {get; set;}
        public string Name{get;set;}
        public int Quantity {get;set;}
        public string Discription{get;set;}
        public double Prices {get;set;}
        public DateTime UsedTime {get;set;}
        public DateTime BiddingDuration{get;set;}

        public int CustomerId {get;set;}
        public string? CustomerName {get;set;}
        public int BiddingPrices {get;set;}

    }
}