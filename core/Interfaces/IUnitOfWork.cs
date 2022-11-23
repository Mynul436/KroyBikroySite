using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;

namespace core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository {get;}
        IProductRepository ProductRepository{get;}
        IRepository<ProductType> TypeRepository{get;}

        IRepository<Picture> ProductPictureRepository{get;}
        IRepository<ProductBid> ProductBidRepository {get;}


        IRepository<ProductRatting> ProductRating {get;}

        IRepository<PaymentRequest>  PaymentRequest {get;}
        
        ICustomerRepository Customer {get;}
        Task CommitAsync();
        Task RollbackAsync();        
    }
}