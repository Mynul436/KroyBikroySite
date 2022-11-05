using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class NewsFeedDto
    {
        public int Id {get; set;}
        public string Name{get;set;}
        public int Quantity {get;set;}
        public string Discription{get;set;}
        public double Prices {get;set;}
        public DateTime UsedTime {get;set;}
        public DateTime BiddingDuration{get;set;}
        public byte[] ProductPhoto{get;set;}
    }
}