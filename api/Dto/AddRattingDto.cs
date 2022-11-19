using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class AddRattingDto
    {
        public double Ratting {get;set;} = 0;

        [Required]
        public string Comment {get;set;}



        public int SellerId {get;set;}
        public int CustomerId {get;set;}

    }
}