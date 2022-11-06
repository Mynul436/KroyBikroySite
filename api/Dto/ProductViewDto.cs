using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class ProductViewDto
    {
        public int Id {get; set;}
        public string Name{get;set;}
        public int Remaining {get;set;}
        public string Discription{get;set;}
        public double Prices {get;set;}
        public DateTime UsedTime {get;set;}
        public DateTime BiddingDuration{get;set;}
        public ICollection<String> ProductPhotos { get; set; } = new List<string>();
       

        public ProductTypeViewDto ProductType {get;set;} = null!;
        public ICollection<ProductBiddingViewDto>? ProductBidding {get;set;}
        public ICollection<ProductRatingViewDto> ProductRatting{get;set;}
        public ProductOwnnerViewDto ProductOwnner{get;set;}
    }
}