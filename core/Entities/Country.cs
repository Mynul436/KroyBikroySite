using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Country : BaseEntity
    {
        public string CountryName {get; set;} = null!;
        public Customer Customer{get;set;}
    }
}