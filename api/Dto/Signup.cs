using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class Signup
    {
        public string UserName{get;set;}
        public string Name{get;set;}
        public string Email{get;set;}
        public string Phone{get;set;}
        public string Password{get;set;}
    }
}