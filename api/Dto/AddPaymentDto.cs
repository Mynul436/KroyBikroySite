using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class AddPaymentDto
    {
        public int ProductId {get;set;}
        public int Prices {get; set;}
        public string TransactionId {get;set;}
    }
}