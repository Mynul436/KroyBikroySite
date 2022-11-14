using core.Entities;
using core.Helpers;

namespace core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        // userParams.PageNumber, userParams.PageSize, userParams, userParams.Type, userParams.LowPrices, userParams.HightPrices, userParams.OrderBy
        Task<PagedList<Product>> newsFeed(UserParams param);

        Task<Product> GetProductById(int Id);

        Task<PagedList<Product>> GetBiddingProduct(int Id, PaginationParams param);
    }

}