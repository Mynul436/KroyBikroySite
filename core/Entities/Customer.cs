using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class Customer : BaseEntity
    {
        
        public string CustomerName {get; set;} = null!;
        public string FatherName {get;set;} = null!;
        public string MotherName {get;set;} = null!;
        public int MaritalStatus {get;set;}
        public byte[] CustomerPhoto {get; set;} = null!;


        public int CountryId {get;set;} 
        public Country? Country{get;set;} 


        
        public ICollection<CustomerAddress>? CustomerAddresses{get;set;}

    }
}