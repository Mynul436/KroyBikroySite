using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Product : BaseEntity
    {
        public string Name{get;set;}
        public int Quantity {get;set;}
        public string Discription{get;set;}
        public double Prices {get;set;}
   
        public DateTime UsedTime {get;set;}
        public DateTime BiddingDuration{get;set;}
        public ICollection<Photo> Photos { get; set; }

        public int TypeId {get;set;}
        public ProductType Type {get;set;}
        public int OwnnerId {get;set;} 
        public User Ownner{get;set;}
    }

}