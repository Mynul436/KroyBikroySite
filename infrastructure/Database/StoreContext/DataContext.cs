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
            
            modelBuilder.Entity<Picture>()
                .HasOne( product => product.Product)
                .WithMany( picture => picture.Photos)
                .HasForeignKey( product => product.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<CustomerAddress>()
            //     .HasOne( c => c.Customer)
            //     .WithMany( address => address.CustomerAddresses)
            //     .HasForeignKey ( c => c.CustomerId)
            //     .OnDelete(DeleteBehavior.Cascade);
        }
           
        public DbSet<User> Users{get;set;}
        public DbSet<Product> Products{get;set;}
        public DbSet<ProductType> ProductType{get;set;}
        public DbSet<Picture> ProductPicture {get;set;}

    }
}