using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class ProductSold : BaseEntity
    {
        public DateTime CreateAt = DateTime.Now;
        public User Seller {get;set;}
        public int SellerId {get;set;}

        public User Customer {get;set;}
        public int CustomerId {get;set;}


        public Product Product {get;set;}
        public int ProductId {get;set;}


        public int Prices {get; set;}
    }
}