using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace api.Dto
{
    public class ProductDto
    {
        public string Name{get;set;}
        public int Quantity {get;set;}
        public string Discription{get;set;}
        public double Prices {get;set;}
        public DateTime UsedTime {get;set;} = DateTime.Now;
        public DateTime BiddingDuration{get;set;} = DateTime.Now;
        public int TypeId {get;set;}
        public IEnumerable<IFormFile> Pictures {get;set;}
        public int OwnnerId {get;set;} 
    }
}