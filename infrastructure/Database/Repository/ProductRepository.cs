using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using core.Entities;
using core.Helpers;
using core.Interfaces;
using infrastructure.Database.Generic;
using infrastructure.Database.StoreContext;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Database.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Product>> GetBiddingProduct(int Id, PaginationParams param)
        {
            var query = _context.Products.AsQueryable();
            
            query = query.Where(filter => filter.OwnnerId == Id);
            query = query.Where( filter => filter.Biddings.Count() > 0);

            var products = await PagedList<Product>.CreateAsync(query, 
                    param.PageNumber, param.PageSize);

            return products;
        }

        public async Task<Product> GetProductById(int Id)
        {
            var product = await _context.Products
                .Include( type => type.Type)
                .Include( photo => photo.Photos)
                .Include( ownner => ownner.Ownner)
                .Include( bidding => bidding.Biddings)
                .Include( ratting => ratting.Rattings)
                .FirstOrDefaultAsync(filter => filter.Id == Id);

            return product;
        }

        public async Task<Object> newsFeed()
        {
            var products = await _context.Products
                .AsNoTracking()
                .AsQueryable()
                .Include(x => x.Type)
                .Include(a => a.Photos)
                .ToListAsync();           
                 
            return products;
        }

        public async Task<PagedList<Product>> newsFeed(UserParams userParams)
        {

            var query = _context.Products.AsQueryable();

            var minPrices = userParams.LowPrices;
            var maxPrices = userParams.HighPrices;

            query = query.Where( prices => prices.Prices >= minPrices && prices.Prices <= maxPrices);

            if(userParams.OrderByBiddingDuration) query = query.OrderByDescending( product => product.BiddingDuration);

            if(userParams.TypeId != -1) query = query.Where( product => product.TypeId == userParams.TypeId);

            query = query.Include(type => type.Type).Include(photo => photo.Photos);

            return await PagedList<Product>.CreateAsync(query, 
                    userParams.PageNumber, userParams.PageSize);
        }
    
        
    }
}