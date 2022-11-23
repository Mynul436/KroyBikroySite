using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class AddPaymentReqestDto
    {
     
        public int ProductId {get;set;}
        public int CustomerId {get;set;}
        public int Prices {get;set;}
    }
}