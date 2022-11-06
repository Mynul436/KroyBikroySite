using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Entities
{
    public class User : BaseEntity
    {
        public string UserName{get;set;}
        public string Name{get;set;}

        public string Email{get;set;}
        public string Phone{get;set;}

        public string Role{get;set;} = "User";
        
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get;set;}

        public IEnumerable<Product>? Product{get;set;}
    }
}