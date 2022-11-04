using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name{get;set;}

        public Product Product {get;set;}
    }
}