using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Bidding : BaseEntity
    {
        public string ProductId {get;set;}
        public double Prices {get;set;}
        public string UserId {get;set;}

        public double Quantity {get;set;}
    }
}