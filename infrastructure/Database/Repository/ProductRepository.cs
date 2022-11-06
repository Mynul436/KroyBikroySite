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
            var maxPrices = userParams.HightPrices;

            query = query.Where( prices => prices.Prices >= minPrices && prices.Prices <= maxPrices);

            if(userParams.OrderByBiddingDuration) query = query.OrderByDescending( product => product.BiddingDuration);

            if(userParams.TypeId != -1) query = query.Where( product => product.TypeId == userParams.TypeId);

            // var products = await query
            //     .Include( type => type.Type)
            //     .Include( photo => photo.Photos)
            //     .Skip((userParams.PageNumber-1) * userParams.PageSize)
            //     .Take(userParams.PageSize).ToListAsync();

            query = query.Include(type => type.Type).Include(photo => photo.Photos);
            
            return await PagedList<Product>.CreateAsync(query, 
                    userParams.PageNumber, userParams.PageSize);
        }
    }
}