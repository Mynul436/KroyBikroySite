using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class RegisterDto
    {
        public string UserName{get;set;}
        public string Name{get;set;}
        public string Email{get;set;}
        public string Phone{get;set;}
    }
}