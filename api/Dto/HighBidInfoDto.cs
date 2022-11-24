using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace api.Dto
{
    public class HighBidInfoDto
    {
        public double Price {get;set;}
        public string Name{get;set;}
        public int UserId {get;set;}

        public bool requstInfo {get;set;} = false;
    }
}