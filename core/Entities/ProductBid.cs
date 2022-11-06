using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class ProductBid : BaseEntity
    {
        public double Price {get;set;}
        public int Quantity {get;set;}

        public Product Product {get;set;}
        public int ProductId {get;set;}
        
        public User User{get;set;}
        public int UserId {get;set;}
    }
}

