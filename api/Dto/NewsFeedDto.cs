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
        public string Type {get;set;}
        public int Prices {get;set;}

        public int HighestBid {get;set;}
        public String PictureURI{get;set;}
    }
}