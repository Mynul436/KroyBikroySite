using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace api.Dto
{
    public class myAddProductViewDto
    {
        public int Id { get; set; }
        public string Name{get;set;}
        public double Prices {get;set;}
        public string TypeName {get;set;}  

        public DateTime BuyingDate {get;set;}
        public DateTime BiddingEndDate {get;set;}
        public HighBidInfoDto HighBidInfo {get;set;}
    }
}