using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
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

        public async Task<List<Product>> newsFeed()
        {
            var products = await _context.Products
                .AsNoTracking()
                .AsQueryable()
                .Include(x => x.Type)
                .Include(a => a.Photos)
                .ToListAsync();

            return products;
        }
    }
}