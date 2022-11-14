using core.Entities;
using Microsoft.EntityFrameworkCore;


namespace infrastructure.Database.StoreContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne( user => user.Ownner)
                .WithMany( product => product.Product)
                .HasForeignKey( product => product.OwnnerId)
                .OnDelete( DeleteBehavior.Cascade);
            
             modelBuilder.Entity<Product>()
                .HasOne(user => user.Type)
                .WithMany(product => product.Product)
                .HasForeignKey(product => product.TypeId)
                .OnDelete( DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Photo>()
                .HasOne( product => product.Product)
                .WithMany( picture => picture.Photos)
                .HasForeignKey( product => product.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<CustomerAddress>()
            //     .HasOne( c => c.Customer)
            //     .WithMany( address => address.CustomerAddresses)
            //     .HasForeignKey ( c => c.CustomerId)
            //     .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ProductRatting>()
                .HasOne( user => user.User)
                .WithMany( ratting => ratting.Rattings)
                .HasForeignKey( key => key.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            
            modelBuilder.Entity<ProductRatting>()
                .HasOne(product => product.Product)
                .WithMany(ratting => ratting.Rattings)
                .HasForeignKey(key => key.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ProductBid>()
                .HasOne( product => product.Product)
                .WithMany( bid => bid.Biddings)
                .HasForeignKey ( bit => bit.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductBid>()
                .HasOne(bid => bid.User)
                .WithMany( user => user.Biddings)
                .HasForeignKey( key => key.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            

            

            modelBuilder.Entity<Message>()
                .HasOne( user => user.ReceiverUser)
                .WithMany( message => message.Messages)
                .HasForeignKey( key => key.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade);



          
        }
           
        public DbSet<User> Users{get;set;}
        public DbSet<Product> Products{get;set;}
        public DbSet<ProductType> ProductType{get;set;}
        public DbSet<Photo> ProductPicture {get;set;}
        public DbSet<ProductBid> ProductBids{get;set;}

        public DbSet<Message> Messages{get;set;}
        public DbSet<ProductSold> ProductSolds{get;set;}

    }
}