using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class ProductRatingViewDto
    {
        public int UserId {get;set;}
        public string Name {get;set;} = "Fahim";
        public int Ratting {get;set;} = 0;
        public string Message {get;set;} = null!;
    }
}