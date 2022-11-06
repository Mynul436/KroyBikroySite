using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Helpers;

namespace core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        // userParams.PageNumber, userParams.PageSize, userParams, userParams.Type, userParams.LowPrices, userParams.HightPrices, userParams.OrderBy
        Task<PagedList<Product>> newsFeed(UserParams param);

        Task<Product> GetProductById(int Id);
    }

}