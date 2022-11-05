namespace core.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name{get;set;}
        public IEnumerable<Product> Product {get;set;}
    }
}