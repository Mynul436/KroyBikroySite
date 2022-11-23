using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace api.Dto
{
    public class ProductViewDto
    {
        public int Id {get; set;}
        public string Name{get;set;}
        public string Description{get;set;}
        public double Prices {get;set;}
        public double HighestBid {get;set;}
        public int TypeId {get;set;}
        public string TypeName {get;set;}  

        public DateTime BuyingDate {get;set;}
        public DateTime BiddingEndDate {get;set;}

        public string District {get;set;}
        public string SubDistrict {get;set;}
        public string Address {get;set;}

        public ICollection<string> Photos { get; set; }        
        
        public ProductOwnnerViewDto Ownner {get;set;}





    }
}