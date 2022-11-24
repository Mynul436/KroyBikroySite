using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class ViewProductPaymentDto
    {
        public int Id {get;set;}
        public string ProductName {get;set;}
        public ProductOwnnerViewDto Ownner {get;set;}
        public int Price {get;set;}
    }
}