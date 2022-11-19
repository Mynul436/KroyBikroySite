using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class Signup
    {
        public string Name{get;set;}
        [Required(ErrorMessage = "Please enter your email address!1")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email{get;set;}
        [Required(ErrorMessage = "Please enter your phone number!!")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string Phone{get;set;}
        public string District {get;set;}
        public string Address {get;set;}


        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password{get;set;}

    }
}