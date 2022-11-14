namespace api.Dto
{
    public class ProductDto
    {
        public string Name{get;set;}
        // public int Quantity {get; protected set;} = 1;
        public string Discription{get;set;}
        public double Prices {get;set;}
        public DateTime UsedTime {get;set;} = DateTime.Now;
        public DateTime BiddingDuration{get;set;} = DateTime.Now.AddDays(7);
        public int TypeId {get;set;}
        public IEnumerable<IFormFile> Pictures {get;set;}
    }
}