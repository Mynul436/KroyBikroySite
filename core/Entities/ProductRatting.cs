using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class ProductRatting : BaseEntity
    {
        public int Ratting {get;set;} = 0;
        public string Message {get;set;}

        public int ProductId {get;set;} 
        public Product Product {get;set;} = null!;

        public int UserId {get;set;}
        public User User {get;set;}
    }
}