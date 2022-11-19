using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class UserRatting : BaseEntity
    {
        public double Ratting {get;set;} = 0;
        public string Comment {get;set;}


        public int SellerId {get;set;}
        public User Seller {get;set;}


        public int CustomerId {get;set;}
        public User Customer {get;set;}
    }
}