using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Product : BaseEntity
    {
        public string Name{get;set;}
        public string Description{get;set;}
        public double Prices {get;set;}

        public int TypeId {get;set;}
        public ProductType Type {get;set;}  

        public DateTime BuyingDate {get;set;}
        public DateTime BiddingEndDate {get;set;}

        public string District {get;set;}
        public string SubDistrict {get;set;}
        public string Address {get;set;}

        public Boolean BiddingStatus = false;

        public ICollection<Photo> Photos { get; set; }        
        public int OwnnerId {get;set;} 
        public User Ownner{get;set;} = null!;
        public ICollection<ProductBid>? Biddings {get;set;}
    }

}