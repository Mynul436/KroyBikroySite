using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace api.Dto
{
    public class AddProductDto
    {
       public string Name{get;set;}
        public string Description{get;set;}
        public double Prices {get;set;}
        public int TypeId {get;set;}

        public DateTime BuyingDate {get;set;}
        public DateTime BiddingEndDate {get;set;}

        public string District {get;set;}
        public string SubDistrict {get;set;}

        public string Address {get;set;}
        public IEnumerable<IFormFile> ProductPhotos { get; set; }

        
    }
}