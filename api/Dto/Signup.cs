using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class Signup
    {
        public string UserName{get;set;}
        [Required(ErrorMessage = "Please enter your name!!")]
        [StringLength(100)]
        public string Name{get;set;}
        [Required(ErrorMessage = "Please enter your email address!1")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email{get;set;}
        [Required(ErrorMessage = "Please enter your phone number!!")]
        [Display(Name = "Phone Number")]
        [Phone]
        public string Phone{get;set;}
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password{get;set;}
    }
}