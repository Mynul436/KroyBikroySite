using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace core.Entities
{
    public class CustomerAddress : BaseEntity
    {
        public int CustomerId {get; set;}
        public Customer Customer{get;set;}
        public string CusAddress {get;set;} = null!;
    }
}