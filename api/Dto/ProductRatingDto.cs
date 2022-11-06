using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class ProductRatingDto
    {
        public int Ratting {get;set;} = 0;
        public string Message {get;set;}
        
        public int ProductId {get;set;} 
    }
}