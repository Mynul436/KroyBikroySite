
using core.Entities;
using core.Interfaces;
using infrastructure.Database.Generic;
using infrastructure.Database.StoreContext;
using infrastructure.Database.Repository;

namespace infrastructure.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        

        public UnitOfWork(DataContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
        }

        public IRepository<User> UserRepository => new Repository<User>(_context);
        public ICustomerRepository Customer => throw new NotImplementedException();
        public IRepository<ProductType> TypeRepository => new Repository<ProductType>(_context);

        public IProductRepository ProductRepository {get; private set;}
        public IRepository<Picture> ProductPictureRepository => new Repository<Picture>(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        
        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}